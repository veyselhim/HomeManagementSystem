import { UserService } from './../../../../services/user/user.service';
import { DuesService } from './../../../../services/dues/dues.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user/user';

@Component({
  selector: 'app-dues-add',
  templateUrl: './dues-add.component.html',
  styleUrls: ['./dues-add.component.css']
})
export class DuesAddComponent implements OnInit {

  users: User[] = [];

  duesAddForm!:FormGroup
  
  constructor(private formBuilder:FormBuilder,private toastrService:ToastrService,private duesService:DuesService,private userService:UserService) { }

  ngOnInit(): void {
    this.createDuesAddForm();
    this.getUsers();
  }

  createDuesAddForm(){
    this.duesAddForm=this.formBuilder.group({
        userId:["",Validators.required],
        amount:["",Validators.required],
        invoiceDate:["",Validators.required],
        status:[false]
    })      
  }

  add(){
    if(this.duesAddForm.valid){
      let duesModel = Object.assign({},this.duesAddForm.value)
      this.duesService.add(duesModel).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
        console.log(data)
      },dataError=>{
        if(dataError.error.Errors.length>0){
          for(let i = 0; i<dataError.error.Errors.length;i++){
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
