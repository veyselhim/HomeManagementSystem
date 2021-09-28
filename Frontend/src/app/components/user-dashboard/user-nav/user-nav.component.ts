import { AuthService } from 'src/app/services/auth/auth.service';
import { LocalStorageService } from './../../../services/localStorage/local-storage.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-nav',
  templateUrl: './user-nav.component.html',
  styleUrls: ['./user-nav.component.css']
})
export class UserNavComponent implements OnInit {

  constructor(private router:Router , private authService:AuthService) { }
  currentUserName!:string;
  ngOnInit(): void {
    this.getCurrentUserName();
    this.isAuthenticated();
  }

  logout(){
    if(confirm("Bizi bırakıp gitmek istediğine emin misin ?")){
      this.router.navigate(["/home"])
      return this.authService.logout();
     
    }
  }

  isAuthenticated(){
    return this.authService.isAuthenticated()
  }

  getCurrentUserName(){
    this.authService.setUserName();
    this.currentUserName=this.authService.currentUserName
  }

}
