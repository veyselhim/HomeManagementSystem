import { LoginModel } from './../../models/login/loginModel';
import { Router } from '@angular/router';
import { LocalStorageService } from './../../services/localStorage/local-storage.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../../services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup , FormControl , Validators , FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  constructor(private formBuilder : FormBuilder , private authService:AuthService , private toastrService:ToastrService, private localStorageService:LocalStorageService) { }

  ngOnInit(): void {
    this.createLoginForm();
    
  }

  createLoginForm(){
    this.loginForm = this.formBuilder.group({
      email:["",Validators.required],
      password:["",Validators.required]
    })
  }


  login(){
    if(this.loginForm.valid){
      let loginModel : LoginModel  = Object.assign({},this.loginForm.value)
      this.authService.login(loginModel)
  }else{
    this.toastrService.info("Lütfen tüm alanları doldurunuz","Bilgilendirme")
  }
}

  isLoggedIn(){
    return this.authService.loggedIn();
    
  }


}
