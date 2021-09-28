import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DuesPayment } from 'src/app/models/duesPayment/duesPayment';
import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DuesPaymentService {

  apiUrl = environment.baseUrl;
  constructor(private httpClient:HttpClient) { }

  
  add(duesPayment:DuesPayment):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"duesPayment/add",duesPayment);
}
}
