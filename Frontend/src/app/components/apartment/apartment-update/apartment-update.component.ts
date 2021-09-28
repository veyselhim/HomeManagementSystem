import { User } from 'src/app/models/user/user';
import { UserService } from './../../../services/user/user.service';
import { ApartmentService } from 'src/app/services/apartment/apartment.service';
import { Apartment } from './../../../models/apartment/apartment';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-apartment-update',
  templateUrl: './apartment-update.component.html',
  styleUrls: ['./apartment-update.component.css']
})
export class ApartmentUpdateComponent implements OnInit {

  
  users:User[] =[];
  apartment:Apartment[] =[];
  apartmentUpdateForm!:FormGroup;
  id!:number;

  constructor(private userService:UserService,private apartmentService:ApartmentService,private formBuilder:FormBuilder,private toastrService:ToastrService,private activetedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activetedRoute.params.subscribe(params=>{
      if(params["id"]){
        this.id = params["id"]
      }
      this.createApartmentUpdateForm();
      this.getUsers();
    })  
  }

  createApartmentUpdateForm(){
    this.apartmentUpdateForm=this.formBuilder.group({
      userId:["",Validators.required],
      type:["",Validators.required],
      floor:["",Validators.required],
      doorNumber:["",Validators.required],
      block:["",Validators.required],
      status:[true]
  })      
  }

  update(){
    if(this.apartmentUpdateForm.valid){
      let apartment:Apartment = Object.assign({id:this.id},this.apartmentUpdateForm.value)
      apartment.id=Number(apartment.id)
      console.log(apartment.id)
      this.apartmentService.update(apartment).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
      },dataError=>{
        if(dataError.error.Errors.length>0){

          for(let i = 0 ; i<dataError.error.Errors.length;i++)
          {
            this.toastrService.error(dataError.error.Errors[i].ErrorMessage)
          }
        }
      })
    }else{
      this.toastrService.error("Formunuz eksik","Dikkat")
    }
  }

  getUsers(){
    this.userService.getUsers().subscribe((response)=>{
      this.users = response.data;
    });
  }
}
