import { BillPayment } from './../../models/billPayment/billPayment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BillPaymentService {


  apiUrl = environment.baseUrl;
  constructor(private httpClient:HttpClient) { }

  
  add(billPayment:BillPayment):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"billPayments/add",billPayment);
}
}
