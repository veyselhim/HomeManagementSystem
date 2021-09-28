import { ApartmentDetail } from './../../models/apartment/apartmentDetail';
import { SingleResponseModel } from './../../models/ResponseModels/singleResponseModel';
import { Apartment } from './../../models/apartment/apartment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/models/ResponseModels/listResponseModel';
import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {

  apiUrl = environment.baseUrl;

  constructor(private httpClient : HttpClient) { }

  add(apartment:Apartment):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"Apartments/add",apartment)
  }


  getApartments():Observable<ListResponseModel<Apartment>>{
    let newPath = this.apiUrl + "apartments/getall"
    return this.httpClient.get<ListResponseModel<Apartment>>(newPath)
  }

  getApartmentDetail(id:number):Observable<SingleResponseModel<ApartmentDetail>>{
    let newPath = this.apiUrl + "apartments/getApartmentDetail?id="+id
    return this.httpClient.get<SingleResponseModel<ApartmentDetail>>(newPath)
  }

  getByUserId(id:number):Observable<SingleResponseModel<Apartment>>{

    let newPath = this.apiUrl + "apartments/getByUserId?id="+id;

    return this.httpClient.get<SingleResponseModel<Apartment>>(newPath);
  }

  update(apartment:Apartment):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"apartments/update",apartment)
  }

  delete(id:number):Observable<ResponseModel>{
    return this.httpClient.delete<ResponseModel>(this.apiUrl+"apartments/delete?id="+id)
  }
}
