import { ApartmentDetail } from './../../../models/apartment/apartmentDetail';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ApartmentService } from 'src/app/services/apartment/apartment.service';
import { Router } from '@angular/router';
import { Apartment } from 'src/app/models/apartment/apartment';


@Component({
  selector: 'app-apartment',
  templateUrl: './apartment.component.html',
  styleUrls: ['./apartment.component.css']
})
export class ApartmentComponent implements OnInit {

  apartments: Apartment[] = [];
  constructor(private toastrService:ToastrService,private apartmentService:ApartmentService,private router:Router) { }

  ngOnInit(): void {
    this.getApartments();
  }

  

  getApartments(){
    this.apartmentService.getApartments().subscribe((response)=>{
      this.apartments = response.data;
    });
  }

  delete(id:number){
    if(confirm("Silmek istediğine emin misin?")){
      this.apartmentService.delete(id).subscribe(data=>{
        console.log(id);
        this.toastrService.success(data.message,"Başarılı")
        //refreshing page
        this.router.navigateByUrl('/ApartmentComponent', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/admin/apartments']);
      }); 

    },dataError=>{
        if(dataError.error.Errors.length>0){
          console.log(dataError.error.Errors)
          for(let i = 0; i<dataError.error.Errors.length;i++){
            this.toastrService.error(dataError.error.Errors[i].ErrorMessage,"Doğrulama Hatası")
          }
        }
      })
    }
  }

}
