import { Component } from '@angular/core';

@Component({
  selector: 'app-button-book-register',
  templateUrl: './button-book-register.component.html',
  styleUrls: ['./button-book-register.component.css']
})
export class ButtonBookRegisterComponent {
  
  showRegister: boolean = false;


  getShowRegister(event: boolean) {
    this.showRegister = event;
  }

}
