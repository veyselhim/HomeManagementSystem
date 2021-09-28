import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { BillDetail } from 'src/app/models/bill/billDetail';
import { BillService } from 'src/app/services/bill/bill.service';
import { Bill } from 'src/app/models/bill/bill';

@Component({
  selector: 'app-bill-detail',
  templateUrl: './bill-detail.component.html',
  styleUrls: ['./bill-detail.component.css']
})
export class BillDetailComponent implements OnInit {

  bills:Bill[]=[];
  userId!:number;
  constructor(private billService:BillService , private authService:AuthService ) { }

  ngOnInit(): void {
    this.getBillsByUser(this.userId);
  
  }

  

  getBillsByUser(id:number):void {
    id = this.authService.getCurrentUserId();
    this.billService.getByUserId(id).subscribe(response=>{
      this.bills = response.data;
    })   
  }

}
