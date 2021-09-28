import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LocalStorageService } from './../localStorage/local-storage.service';
import { SingleResponseModel } from './../../models/ResponseModels/singleResponseModel';
import { TokenModel } from './../../models/token/tokenModel';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService} from "@auth0/angular-jwt";
import { LoginModel } from './../../models/login/loginModel';
import { Injectable } from '@angular/core';
import { RegisterModel } from 'src/app/models/register/registerModel';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  apiUrl = environment.baseUrl;
  currentUserId!:number
  currentUserName!:string
  currentRoles!:string
  jwtHelperService:JwtHelperService = new JwtHelperService
  constructor(private httpClient : HttpClient , private localStorageService:LocalStorageService,private toastrService:ToastrService,private router:Router) { }


//**Login and register operations Start**//
login(user:LoginModel) {
  return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl + "auth/login",user).subscribe(response=>{
    if(response.success){
      this.localStorageService.setToken(response.data.token)
      this.toastrService.success("Giriş yapıldı","Başarılı")
      this.setRoles()
      if(this.currentRoles=="admin"){
        this.router.navigate(["admin"])
      }else{
        this.router.navigate(["userdashboard"])
      }
      this.setUserName()
      this.setCurrentUserId()
      this.getCurrentUserName();
      setTimeout(function(){
        location.reload()
      },400)
    }
    },responseError => {
      this.toastrService.error(responseError.error,"Hata")
  })
}


register(registerModel:RegisterModel):Observable<SingleResponseModel<TokenModel>>{
  return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl+"auth/register",registerModel);
}


logout(){
  this.localStorageService.remove("token")
}

//**Login and register operations End**//


//**Current user operations Start**//


getCurrentUserId():number {
  console.log(this.currentUserId);
  return this.currentUserId

}

setCurrentUserId(){
  var decoded = this.getDecodedToken()
  var propUserId = Object.keys(decoded).filter(x => x.endsWith("/nameidentifier"))[0];
  this.currentUserId = Number(decoded[propUserId]);
}


setUserName(){
  var decoded = this.getDecodedToken()
  var propUserName = Object.keys(decoded).filter(x => x.endsWith("/name"))[0];
  this.currentUserName = decoded[propUserName];
}

getCurrentUserName() :string{
 return this.currentUserName;
}


//**Current user operations End**//

//***Role Operations Start**//

setRoles() {
  var decoded = this.getDecodedToken()
  var propUserId = Object.keys(decoded).filter(x => x.endsWith("/role"))[0];
  this.currentRoles = String(decoded[propUserId]);
}

getCurrentRoles(): string {
  
  return this.currentRoles
}

//***Role Operations End**//





//**Checking authenticate loging and email Start**//

isAuthenticated(){
  if(localStorage.getItem("token")){
    return true;
  }else{
    return false;
  }
}

isAdmin(){
  if(this.currentRoles=="admin"){
    console.log(this.currentRoles)
    return true;
  }else{
    return false;
  }
}

checkToEmail(){
  let email = this.localStorageService.get('email');
  console.log(email);
}

loggedIn(): boolean {
  let isExpired = this.jwtHelperService.isTokenExpired(this.localStorageService.getToken()!);
  console.log(isExpired);
  return !isExpired;
}

//**Checking authenticate and loging and email End**//




async setUserStats(){
  if(this.loggedIn()){
    this.setCurrentUserId()
  }
}

getDecodedToken(){
  try{
    let decodedToken = this.jwtHelperService.decodeToken(this.localStorageService.getToken()!);
    return decodedToken;
  }
  catch(Error){
      return null;
  }
}


}