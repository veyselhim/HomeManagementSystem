import { CardDocument } from 'src/app/models/cardDocument/cardDocument';
import { ListResponseModel } from './../../models/ResponseModels/listResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CardDocumentService {

  apiUrl = environment.baseUrl;
  constructor(private httpClient:HttpClient) { }


  add(cardDocument:CardDocument):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"cardDocuments/add",cardDocument)
  }

  getCardDocuments():Observable<ListResponseModel<CardDocument>>{
    let newPath = this.apiUrl + "cardDocuments/getall"
    return this.httpClient.get<ListResponseModel<CardDocument>>(newPath)
  }

  getByUserId(id:number):Observable<ListResponseModel<CardDocument>>{

    let newPath = this.apiUrl + "cardDocuments/getByUserId?id="+id;

    return this.httpClient.get<ListResponseModel<CardDocument>>(newPath);
  }

  update(cardDocument:CardDocument):Observable<ResponseModel>{
    return this.httpClient.put<ResponseModel>(this.apiUrl+"cardDocuments/update",cardDocument)
  }

  delete(id:string):Observable<ResponseModel>{
    return this.httpClient.delete<ResponseModel>(this.apiUrl+"cardDocuments/delete?id="+id)
  }

}
