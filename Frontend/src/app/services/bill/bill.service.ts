import { BillDetail } from './../../models/bill/billDetail';
import { ResponseModel } from './../../models/ResponseModels/responseModel';
import { Observable } from 'rxjs';
import { Bill } from './../../models/bill/bill';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/models/ResponseModels/listResponseModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  apiUrl = environment.baseUrl;

  constructor(private httpClient : HttpClient) { }

  add(bill:Bill):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"bills/add",bill)
  }

  getByUserId(id:number):Observable<ListResponseModel<Bill>>{

    let newPath = this.apiUrl + "bills/getByUserId?id="+id;

    return this.httpClient.get<ListResponseModel<Bill>>(newPath);
  }

  getBills():Observable<ListResponseModel<Bill>>{
    let newPath = this.apiUrl + "bills/getall";

    return this.httpClient.get<ListResponseModel<Bill>>(newPath);
  }

  getBillDetails():Observable<ListResponseModel<BillDetail>>{
    let newPath = this.apiUrl + "bills/getBilLDetails";

    return this.httpClient.get<ListResponseModel<BillDetail>>(newPath);
  }

}
