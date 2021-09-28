import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from 'src/app/services/apartment/apartment.service';

@Component({
  selector: 'app-apartment-detail',
  templateUrl: './apartment-detail.component.html',
  styleUrls: ['./apartment-detail.component.css']
})
export class ApartmentDetailComponent implements OnInit {

  currentApartment:any;
  constructor(private apartmentService:ApartmentService , private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["id"]){
        this.getApartmentDetail(params["id"]);
      }
    })
    
  }


  getApartmentDetail(id:number){
    console.log(id)
    this.apartmentService.getApartmentDetail(id).subscribe(response=>{
      console.log(response)
      this.currentApartment=response.data;
    })

  }

}
