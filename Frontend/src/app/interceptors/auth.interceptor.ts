import { LocalStorageService } from './../services/localStorage/local-storage.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private localStorageService : LocalStorageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let token = this.localStorageService.get("token"); 
    let newRequest : HttpRequest<any>
    newRequest = request.clone({
      headers: request.headers.set("Authorization","Bearer " +token)
    })
    return next.handle(newRequest);
  }
}
