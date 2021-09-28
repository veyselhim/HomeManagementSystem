import { LocalStorageService } from './../../services/localStorage/local-storage.service';
import { User } from 'src/app/models/user/user';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  currentUserName! :string;
  userLogged!:boolean;
  currentRole! :string;

  constructor(private authService:AuthService ,private localStorageService:LocalStorageService) { }
  
  
  ngOnInit(): void {
    this.getCurrentUserName();
    this.setUserLogged();
  }


  getCurrentUserName(){
     this.currentUserName = this.authService.getCurrentUserName();
  }


  
  setUserLogged(){
    this.userLogged = this.authService.loggedIn()
  }



 

}
