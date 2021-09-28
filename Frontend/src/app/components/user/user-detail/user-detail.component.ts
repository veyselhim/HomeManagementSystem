import { DuesService } from '../../../services/dues/dues.service';
import { Bill } from '../../../models/bill/bill';
import { BillService } from '../../../services/bill/bill.service';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from 'src/app/services/apartment/apartment.service';
import { Component, OnInit } from '@angular/core';
import { Dues } from 'src/app/models/dues/dues';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  currentApartment:any;
  bills:Bill[] = [];
  dueses:Dues[] = [];

  constructor(private duesService:DuesService , private apartmentService:ApartmentService , private activatedRoute : ActivatedRoute , private billService:BillService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["id"]){
        this.getApartmentByUser(params["id"]);
        this.getBillsByUser(params["id"]);
        this.getDuesesByUser(params["id"]);
      }
    })
  }


  getApartmentByUser(id:number):void {
    this.apartmentService.getByUserId(id).subscribe(response=>{
      this.currentApartment = response.data;
    })   
}

getBillsByUser(id:number):void {
  this.billService.getByUserId(id).subscribe(response=>{
    this.bills = response.data;
  })   
}

getDuesesByUser(id:number):void {
  this.duesService.getByUserId(id).subscribe(response=>{
    this.dueses = response.data;
    console.log(response);

  }) 
    
}

}
