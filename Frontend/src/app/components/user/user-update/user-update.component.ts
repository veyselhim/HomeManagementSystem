import { UserService } from './../../../services/user/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {
  
  date = new Date().toJSON("yyyy/MM/dd HH:mm");
  userUpdateForm!:FormGroup;
  id!:number;
  
  constructor(private userService:UserService,private formBuilder:FormBuilder,private toastrService:ToastrService,private activetedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activetedRoute.params.subscribe(params=>{
      if(params["id"]){
        this.id = params["id"]
      }
      this.createUserUpdateForm();

    })  
  }

  createUserUpdateForm(){
    this.userUpdateForm=this.formBuilder.group({
      id:this.id,
      firstName:["",Validators.required],
      lastName:["",Validators.required],
      identityNumber:["",Validators.required],
      email:["",Validators.required],
      phone:["",Validators.required],
      vehiclePlateNumber:["",Validators.required],
      password:["",Validators.required],
      joinDate:[this.date],
      status:[true]

  })      
  }
  
  update(){
    if(this.userUpdateForm.valid){
      let userModel = Object.assign({},this.userUpdateForm.value)
      this.userService.update(userModel).subscribe(response=>{
        this.toastrService.success(response.message,"Başarılı")
      },responseError=>{
        if(responseError.error.Errors.length>0){
          for (let i = 0; i < responseError.error.Errors.length; i++) {
            
            this.toastrService.error(responseError.error.Errors[i].ErrorMessage,"Doğrulama Hatası")
        }
        }
      })
    }else{
      this.toastrService.error("Formunuz eksik","Dikkat")
    }
  }

 
}
