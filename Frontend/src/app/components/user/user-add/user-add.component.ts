import { UserService } from './../../../services/user/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

  date = new Date().toJSON("yyyy/MM/dd HH:mm");
 
  registerForm!:FormGroup
 
  constructor(private formBuilder:FormBuilder,
    private authService:AuthService,
    private toastrService:ToastrService,
    private router:Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm=this.formBuilder.group({
      firstName:["",Validators.required],
      lastName:["",Validators.required],
      email:["",Validators.required],
      password:["",Validators.required],
      identityNumber:["",Validators.required],
      phone:["",Validators.required],
      vehiclePlateNumber:["",Validators.required],
      joinDate:[this.date],
      status:[true]
    })
  }



  register(){
    if(this.registerForm.valid){
      let registerModel = Object.assign({},this.registerForm.value)
      this.authService.register(registerModel).subscribe(response=>{
        this.toastrService.success(response.message)
      },responseError=>{
        if(responseError.error.Errors.length>0){

          for(let i = 0 ; i<responseError.error.Errors.length;i++)
          {
            this.toastrService.error(responseError.error.Errors[i].ErrorMessage)
          }
        }
      })
    }else{
      this.toastrService.error("Formunuz Eksik","Dikkat")
    }
  }

}
