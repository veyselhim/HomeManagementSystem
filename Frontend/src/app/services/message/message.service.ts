import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';
import { Observable } from 'rxjs';
import { MessageDetail } from './../../models/message/messageDetail';
import { ListResponseModel } from 'src/app/models/ResponseModels/listResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  apiUrl:string = environment.baseUrl;

  constructor(private httpClient:HttpClient) { }

  getMessageDetails(){
    let newPath = this.apiUrl+"messages/getMessageDetails";
      this.httpClient.get<ListResponseModel<MessageDetail>>(newPath);
  }

  add(message:Message):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"messages/add",message) 
  }

}
