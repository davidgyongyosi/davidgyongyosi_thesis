import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ModalService } from '../../services/modal/modal.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  constructor (private router: Router, private modalService: ModalService) {}

  get_started() {
    if(localStorage.getItem('token') != null){
      this.router.navigate(['/Events']);
    }
    else {
      this.modalService.openLoginModal();
    }
  }
}
