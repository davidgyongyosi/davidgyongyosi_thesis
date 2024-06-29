import { Component, ElementRef, OnInit, Renderer2, AfterViewInit, ViewChild } from '@angular/core';
import { environment } from '../../../environments/environment';
import { MapData, MapView, Path, TDirectionInstruction, getMapData, show3dMap } from '@mappedin/mappedin-js';
import { Location } from 'src/app/models/location.model';
import { Floor } from 'src/app/models/floor.model';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-map',
  templateUrl: './map.page.html',
  styleUrls: ['./map.page.scss'],
})
export class MapPage implements OnInit, AfterViewInit{
  mapData!: MapData;
  mapView!: MapView;

  locations: any[] = [];
  endLocation?: string;
  startLocation?: string;
  showDirectionOptions = false;
  isLoading = false;
  isNavigating = false;
  floors: Floor[] = [];
  selectedFloor!: string;
  currentSelection: 'start' | 'end' = 'end';

  constructor(
    private el: ElementRef,
    private renderer: Renderer2,
    private toastController: ToastController
  ) {}
  async ngOnInit() {
    await this.initMap();

    this.addInteractivity(this.mapData, this.mapView);
    this.addLabels();
  }

  ngAfterViewInit(): void {}

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
      this.toastController.create({
        message: 'Error loading map',
        duration: 1000,
        position: 'top',
      });
    } finally {
      this.isLoading = false;
    }
    
  }

  selectLocationOnMap(locationName: string) {
    if (this.currentSelection === 'end') {
      this.endLocation = locationName;
      this.toastController.create({
        message: `End location set to ${locationName}.`,
        duration: 1000,
        position: 'top',
      });
      this.currentSelection = 'start';
    } else {
      this.startLocation = locationName;
      this.toastController.create({
        message: `Start location set to ${locationName}.`,
        duration: 1000,
        position: 'top',
      });
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
    this.toastController.create({
      message: `Selected ${selectionType} location: ${value}.`,
      duration: 1000,
      position: 'top',
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
          this.toastController.create({
            message: 'Select a location to get started',
            duration: 1000,
            position: 'top',
          });
          return;
        }

        const clickedLocationName = event.spaces[0].name;

        if (this.currentSelection === 'end') {
          this.endLocation = clickedLocationName;
          this.currentSelection = 'start';
          this.toastController.create({
            message: `End location set to ${clickedLocationName}.`,
            duration: 1000,
            position: 'top',
          });
        } else {
          this.currentSelection = 'end';
          this.startLocation = clickedLocationName;
          this.toastController.create({
            message: `Start location set to ${clickedLocationName}.`,
            duration: 1000,
            position: 'top',
          });
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
    const locationstoService: Location[] = [];

    this.mapData.getByType('space').forEach((space, index) => {
      if (space.name) {
        let name = space.name;
        const color = colors[index % colors.length];

        const location: Location = new Location();
        location.id = space.id;
        location.name = name;

        locationstoService.push(location);

        this.locations.push(name);

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
      this.toastController.create({
        message: 'Please select both a start and an end location.',
        duration: 1000,
        position: 'top',
      });
      return;
    }

    const firstSpace = this.mapData
      .getByType('space')
      .find((s) => s.name === this.startLocation);
    const secondSpace = this.mapData
      .getByType('space')
      .find((s) => s.name === this.endLocation);

    
    this.toastController.create({
      message: `Navigation started from ${firstSpace?.name} to ${secondSpace?.name}.`,
      duration: 1000,
      position: 'top',
    });
    
    
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

}
