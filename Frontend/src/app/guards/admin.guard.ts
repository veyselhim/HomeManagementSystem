import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authService:AuthService , private router:Router , private toastrService:ToastrService ){}
  currentRole! : string;
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      this.authService.setRoles();
      this.currentRole = this.authService.currentRoles;
      if(this.currentRole=="admin"){
        
        return true;
      }else{
        this.router.navigate(["userdashboard"])
        this.toastrService.error("Admin yetkiniz yok !")
        return false;
      }
  }

 
  
}
