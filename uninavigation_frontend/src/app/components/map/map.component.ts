import {
  Component,
  ElementRef,
  OnInit,
  Renderer2,
} from '@angular/core';
import { environment } from '../../../environments/environment';
import {
  MapData,
  MapView,
  getMapData,
  show3dMap,
} from '@mappedin/mappedin-js';
//import '@mappedin/mappedin-js/lib/index.css';
import { Floor } from '../../models/floor.model';
import { NzMessageService } from 'ng-zorro-antd/message';
import { LocationService } from '../../services/location/location.service';
import { Location } from '../../models/location.model';
import { MapCommunicationService } from '../../services/map/map-communication.service';
import { ArContent } from '../../models/ar_content.model';
import { AuthGuard } from '../../services/auth/auth.guard';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.scss',
})
export class MapComponent implements OnInit {
  mapData!: MapData;
  mapView!: MapView;

  nearestEntrance = "Nearest Entrace"; 
  locations: any[] = [];
  endLocation?: string;
  startLocation?: string;
  showDirectionOptions = false;
  isLoading = false;
  isNavigating = false;
  floors: Floor[] = [];
  selectedFloor!: string;
  currentSelection: 'start' | 'end' = 'end';
  locationstoService: Location[] = [];
  userIsAdmin = false;

  constructor(
    private el: ElementRef,
    private renderer: Renderer2,
    private message: NzMessageService,
    private authGuard: AuthGuard,
    private service: LocationService,
    private mapCommunicationService: MapCommunicationService
  ) {}
  async ngOnInit() {
    if(!this.mapData){
      await this.initMap();
    }
    
    this.userIsAdmin = this.authGuard.isAdmin();

    this.addInteractivity(this.mapData, this.mapView);
    this.addLabels();
    this.setupControls(this.mapView);
    this.loadLocationsAndARContent();
    
  }

  async initMap() {
    this.isLoading = true;

    try {
      this.mapData = await getMapData({
        key: environment.MappedinKey,
        secret: environment.MappedinSecret,
        mapId: environment.MappedinMap,
      });
  
      this.mapView = await show3dMap(
        this.el.nativeElement.querySelector('#map'),
        this.mapData
      );
  
      this.mapData.getByType('floor').forEach((floor) => {
        const floorModel = new Floor();
  
        floorModel.name = floor.name;
        floorModel.id = floor.id;
  
        this.floors.push(floorModel);
      });
  
      this.floors.sort((a, b) => a.name.localeCompare(b.name));
      this.selectedFloor = this.mapView.currentFloor.id;
    } catch (error) {
      this.message.error('Error loading map');
    } finally {
      this.isLoading = false;
    }
    
  }
  selectLocationOnMap(locationName: string) {
    if (this.currentSelection === 'end') {
      this.endLocation = locationName;
      this.message.success(`End location set to ${locationName}.`);
      this.currentSelection = 'start';
    } else {
      this.startLocation = locationName;
      this.message.success(`Start location set to ${locationName}.`);
    }
  }

  onLocationSelected(value: string, selectionType: 'start' | 'end'): void {
    if (selectionType === 'end') {
      this.endLocation = value;
      this.currentSelection = 'start';
    } else {
      this.startLocation = value;
      this.currentSelection = 'end';
    }
    this.message.info(`Selected ${selectionType} location: ${value}.`);
  }

  setupControls(mapView: MapView) {
    const controlButtons =
      this.el.nativeElement.querySelectorAll('.map-control');
    controlButtons.forEach((button: Element) => {
      this.renderer.listen(button, 'click', () => {
        const transform: {
          pitch?: number;
          bearing?: number;
          zoomLevel?: number;
        } = {};
        switch (button.getAttribute('data-action')) {
          case 'pitch-up':
            transform.pitch = mapView.Camera.pitch + 20;
            break;
          case 'pitch-down':
            transform.pitch = mapView.Camera.pitch - 20;
            break;
          case 'bearing-left':
            transform.bearing = (mapView.Camera.bearing - 45) % 360;
            break;
          case 'bearing-right':
            transform.bearing = (mapView.Camera.bearing + 45) % 360;
            break;
          case 'zoom-in':
            transform.zoomLevel = mapView.Camera.zoomLevel + 0.8;
            break;
          case 'zoom-out':
            transform.zoomLevel = mapView.Camera.zoomLevel - 0.8;
            break;
          case 'direction':
            transform.zoomLevel = mapView.Camera.zoomLevel - 10;
            break;
        }
        mapView.Camera.animate(transform);
      });
    });
  }

  addInteractivity(mapData: MapData, mapView: MapView) {
    mapData.getByType('space').forEach((space) => {
      mapView.updateState(space, {
        interactive: true,
      });
    });

    mapView.on('click', async (event) => {
      if (!this.isNavigating) {
        if (!event.spaces[0]) {
          this.message.info('Select a location to get started');
          return;
        }

        const clickedLocationName = event.spaces[0].name;

        if (this.currentSelection === 'end') {
          this.endLocation = clickedLocationName;
          this.currentSelection = 'start';
          this.message.success(`End location set to ${clickedLocationName}.`);
        } else {
          this.currentSelection = 'end';
          this.startLocation = clickedLocationName;
          this.message.success(`Start location set to ${clickedLocationName}.`);
        }

        mapView.Camera.focusOn(event.spaces[0], {
          maxZoomLevel: 12,
          duration: 1000,
        });
      }
    });
  }

  addLabels() {
    const icon = `<svg version="1.0" xmlns="http://www.w3.org/2000/svg"
    width="723.000000pt" height="723.000000pt" viewBox="0 0 723.000000 723.000000"
    preserveAspectRatio="xMidYMid meet">
   <g transform="translate(0.000000,723.000000) scale(0.100000,-0.100000)"
   fill="#ffffff" stroke="none" clip-path="url(#clip0)">
   <path d="M0 3615 l0 -3615 3615 0 3615 0 0 3615 0 3615 -3615 0 -3615 0 0
   -3615z m2830 2136 c6 -12 10 -92 10 -190 0 -158 -1 -171 -19 -181 -13 -6 -179
   -10 -471 -10 -292 0 -458 4 -471 10 -18 10 -19 23 -19 188 0 125 4 182 12 190
   9 9 129 12 480 12 452 0 468 -1 478 -19z m-357 -771 c311 -30 591 -159 819
   -378 168 -162 281 -340 352 -552 88 -264 91 -566 9 -830 -127 -409 -461 -754
   -863 -891 -139 -47 -220 -60 -395 -66 -132 -4 -191 -1 -265 11 -428 74 -790
   336 -989 716 -152 290 -194 624 -120 940 124 529 561 944 1089 1034 159 27
   218 29 363 16z m3715 -2 c13 -13 18 -351 6 -382 -6 -14 -84 -16 -780 -16
   l-774 0 0 -960 0 -960 778 -2 777 -3 0 -195 0 -195 -982 -3 -983 -2 0 1359 c0
   1078 3 1360 13 1364 6 3 444 6 973 6 734 1 963 -2 972 -11z m10 -1338 c1 -96
   0 -185 -3 -197 l-5 -23 -485 0 -485 0 0 200 0 200 488 -2 487 -3 3 -175z"/>
   <path d="M2160 4561 c-209 -46 -352 -125 -492 -269 -129 -132 -205 -269 -254
   -457 -25 -95 -25 -330 -1 -429 90 -359 359 -630 714 -718 117 -29 313 -31 427
   -4 313 72 563 283 683 576 60 147 83 319 64 477 -48 394 -329 712 -718 814
   -115 30 -311 35 -423 10z"/>
   </g>
   </svg>`;

    const colors = ['blue', 'purple', 'green', 'orange', 'tomato', 'gray'];

    this.mapData.getByType('space').forEach((space, index) => {
      if (space.name) {
        const color = colors[index % colors.length];
        this.mapView.Labels.add(space, space.name, {
          appearance: {
            marker: {
              foregroundColor: {
                active: color,
                inactive: color,
              },
              icon: icon,
              iconSize: 12,
            },
            text: {
              foregroundColor: color,
              size: 12,
            },
          },
        });
      }      
    });

    this.mapData.getByType('floor').forEach((floor) => {
      this.mapData.getByType('connection').forEach((connection) => {
        connection.coordinates
        const coords = connection.coordinates.find(
          (coord) => coord.floorId === floor.id
        );
        if (coords) {
        this.mapView.Labels.add(coords, connection.name);
        }
      })  
    })
    
  }

  navigate() {

    if (!this.startLocation || !this.endLocation) {
      this.message.error('Please select both a start and an end location.');
      return;
    }

    const firstSpace = this.mapData
      .getByType('space')
      .find((s) => s.name === this.startLocation);
    const secondSpace = this.mapData
      .getByType('space')
      .find((s) => s.name === this.endLocation);

    this.message.success(
      `Navigation started from ${firstSpace?.name} to ${secondSpace?.name}.`
    );
    
    if (firstSpace && secondSpace) {
      const directions = this.mapView.getDirections(firstSpace, secondSpace);

      if (directions) {
        this.mapView.Navigation.draw(directions);
        this.isNavigating = true;
      } else {
        this.isNavigating = false;
      }
    }
  }

  clearNavigation() {
    this.mapView.Navigation.clear();
    this.endLocation = '';
    this.startLocation = '';
    this.isNavigating = false;
    this.showDirectionOptions = false;
  }

  changeFloor(floor: string) {
    this.mapView.setFloor(floor);
  }

  loadLocationsAndARContent() {
      this.mapData.getByType('space').forEach((space) => {
        if (space.name) {
          let name = space.name;
        const location: Location = new Location();
        location.id = space.center.id;
        location.name = space.name;
        location.ar_Content = new ArContent();
        location.ar_Content.roomName = space.name;
        location.ar_Content.longitude = space.center.longitude.toString();
        location.ar_Content.latitude = space.center.latitude.toString();
        location.ar_Content.elevation = space.floor.elevation;
        this.locationstoService.push(location);

        this.locations.push(space.name);
      }
    });
  }

  pushLocationsAndARContent() {
    this.service.restoreLocations().subscribe(resp => {
      console.log(resp);
      if(resp.message == "Done"){
        this.service.addLocations(this.locationstoService).subscribe(resp => {
          console.log(resp);
        }
        );
      }
    });
    
  }

}