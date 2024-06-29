import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage {

  constructor(private router: Router) {}

  get_started() {
    if(localStorage.getItem('token') != null) {
      this.router.navigate(['/about']);
    } else {
      this.router.navigate(['/login']);
    }
  }
}
