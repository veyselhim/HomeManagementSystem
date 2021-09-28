import { UserService } from './../../../services/user/user.service';
import { User } from 'src/app/models/user/user';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ApartmentService } from 'src/app/services/apartment/apartment.service';

@Component({
  selector: 'app-apartment-add',
  templateUrl: './apartment-add.component.html',
  styleUrls: ['./apartment-add.component.css']
})
export class ApartmentAddComponent implements OnInit {

  users: User[] = [];

  apartmentAddForm!:FormGroup

  constructor(private formBuilder:FormBuilder,private toastrService:ToastrService,private apartmentService:ApartmentService,private userService:UserService) { }

  ngOnInit(): void {
    this.createApartmentForm();
    this.getUsers();
  }

  createApartmentForm(){
    this.apartmentAddForm=this.formBuilder.group({
        type:["",Validators.required],
        userId:["",Validators.required],
        floor:["",Validators.required],
        doorNumber:["",Validators.required],
        block:["",Validators.required],
        status:[true],
    })      
  }


  add(){
    if(this.apartmentAddForm.valid){
      let apartmanModel = Object.assign({},this.apartmentAddForm.value)
      this.apartmentService.add(apartmanModel).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
      },dataError=>{
        if(dataError.error.Errors.length>0){
          for (let i = 0; i < dataError.error.Errors.length; i++) {
            
              this.toastrService.error(dataError.error.Errors[i].ErrorMessage,"Doğrulama Hatası")
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
