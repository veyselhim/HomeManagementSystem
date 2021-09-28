import { UserService } from './../../../services/user/user.service';
import { BillService } from './../../../services/bill/bill.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user/user';

@Component({
  selector: 'app-bill-add',
  templateUrl: './bill-add.component.html',
  styleUrls: ['./bill-add.component.css']
})
export class BillAddComponent implements OnInit {

  users: User[] = [];
  billAddForm!:FormGroup

  constructor(private formBuilder:FormBuilder,private toastrService:ToastrService,private billService:BillService,private userService:UserService) { }

  ngOnInit(): void {
    this.createBillForm();
    this.getUsers();
  }

  createBillForm(){
    this.billAddForm=this.formBuilder.group({
        userId:["",Validators.required],  
        type:["",Validators.required],
        invoiceDate:["",Validators.required],
        amount:["",Validators.required],
        status:[false],
    })      
  }


  add(){
    if(this.billAddForm.valid){
      let billModel = Object.assign({},this.billAddForm.value)
      this.billService.add(billModel).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
      },responseError=>{
        if(responseError.error.Errors.length>0){
          for(let i = 0; i<responseError.error.Errors.length;i++){
            this.toastrService.error(responseError.error.Errors[i].ErrorMessage,"Doğrulama Hatası")
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
