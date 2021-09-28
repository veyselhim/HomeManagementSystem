import { ResponseModel } from './../../models/ResponseModels/responseModel';
import { Observable } from 'rxjs';
import { Dues } from './../../models/dues/dues';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/models/ResponseModels/listResponseModel';
import { environment } from 'src/environments/environment';
import { DuesDetail } from 'src/app/models/dues/duesDetail';

@Injectable({
  providedIn: 'root'
})
export class DuesService {

  apiUrl = environment.baseUrl;


  constructor(private httpClient:HttpClient) { }

  add(dues:Dues):Observable<ResponseModel>{
      return this.httpClient.post<ResponseModel>(this.apiUrl+"dueses/add",dues);
  }

  
  getByUserId(id:number):Observable<ListResponseModel<Dues>>{

    let newPath = this.apiUrl + "dueses/getByUserId?id="+id;

    return this.httpClient.get<ListResponseModel<Dues>>(newPath);
  }

  getDueses():Observable<ListResponseModel<Dues>>{
    let newPath = this.apiUrl + "dueses/getall";

    return this.httpClient.get<ListResponseModel<Dues>>(newPath);
  }

  getDuesDetails():Observable<ListResponseModel<DuesDetail>>{
    let newPath = this.apiUrl + "dueses/getDuesDetails";

    return this.httpClient.get<ListResponseModel<DuesDetail>>(newPath);
  }

 
}
