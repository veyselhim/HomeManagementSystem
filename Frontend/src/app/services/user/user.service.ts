import { ListResponseModel } from './../../models/ResponseModels/listResponseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/ResponseModels/responseModel';
import { SingleResponseModel } from 'src/app/models/ResponseModels/singleResponseModel';
import { TokenModel } from 'src/app/models/token/tokenModel';
import { User } from 'src/app/models/user/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = environment.baseUrl;

  constructor(private httpClient : HttpClient) { }


  delete(id:number):Observable<ResponseModel>{
    return this.httpClient.delete<ResponseModel>(this.apiUrl+"users/delete?id="+id)
  }

  
  getById(id:number):Observable<SingleResponseModel<User>>{

    let newPath = this.apiUrl + "users/getById?id="+id;

    return this.httpClient.get<SingleResponseModel<User>>(newPath);
  }

  
  getUsers():Observable<ListResponseModel<User>>{
    let newPath = this.apiUrl + "users/getall"
    return this.httpClient.get<ListResponseModel<User>>(newPath)
  }

  getByEmail(email:string):Observable<User>{
    return this.httpClient.get<User>(this.apiUrl+"users/getByEmail?email="+email)
  }

  update(user:User):Observable<ListResponseModel<TokenModel>>{
    return this.httpClient.post<ListResponseModel<TokenModel>>(this.apiUrl+"users/editProfile",user);
  }
 
}
