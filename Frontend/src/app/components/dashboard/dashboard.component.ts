import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {

  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
  }

  logout(){
    if(confirm("Bizi bırakıp gitmek istediğine emin misin ?")){
      //this.localStorageService.remove("token")
      this.router.navigate(["/home"])
      return this.authService.logout();
     
    }
  }


}
