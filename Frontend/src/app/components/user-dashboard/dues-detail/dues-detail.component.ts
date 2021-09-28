import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { Dues } from 'src/app/models/dues/dues';
import { DuesDetail } from 'src/app/models/dues/duesDetail';
import { DuesService } from 'src/app/services/dues/dues.service';

@Component({
  selector: 'app-dues-detail',
  templateUrl: './dues-detail.component.html',
  styleUrls: ['./dues-detail.component.css']
})
export class DuesDetailComponent implements OnInit {

  dueses:Dues[]=[];
  userId!:number;
  constructor( private duesService:DuesService , private authService:AuthService ) { }

  ngOnInit(): void {
    this.getBillsByUser(this.userId);
  }

  
  getBillsByUser(id:number):void {
    id = this.authService.getCurrentUserId();
    this.duesService.getByUserId(id).subscribe(response=>{
      this.dueses = response.data;
    })   
  }
}
