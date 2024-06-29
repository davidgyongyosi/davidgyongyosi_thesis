import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-ar-content',
  templateUrl: './ar-content.component.html',
  styleUrls: ['./ar-content.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class ArContentComponent  implements OnInit {
  constructor(private modalCtrl: ModalController) {}

  ngOnInit() {}

  close() {
    this.modalCtrl.dismiss();
  }
}
