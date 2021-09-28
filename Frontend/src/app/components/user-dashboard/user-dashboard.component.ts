import { DuesDetail } from './../../models/dues/duesDetail';
import { BillDetail } from './../../models/bill/billDetail';
import { Dues } from './../../models/dues/dues';
import { DuesService } from './../../services/dues/dues.service';
import { BillService } from './../../services/bill/bill.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LocalStorageService } from './../../services/localStorage/local-storage.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {

  dueses:Dues[]=[];
  billDetails:BillDetail[]=[];
  duesDetails:DuesDetail[]=[];

  constructor(private duesService:DuesService ,private authService:AuthService ) { }

  ngOnInit(): void {
 //   this.getDueses();
   // this.authService.getDecodedToken();
    //this.authService.loggedIn();
    this.authService.setCurrentUserId();
    this.authService.getCurrentUserId();
  
  }

 


 

}
