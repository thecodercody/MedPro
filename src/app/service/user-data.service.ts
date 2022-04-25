import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {
  _http:HttpClient;

  dataService:any;
  isLoginService:any;

  createUser:any  = { 
    firstName:"", 
    lastName:"",
    email:"",
    password:"",
    role:1
  }; 

  constructor(private _httpRef : HttpClient) {
    this._http = _httpRef;
   }

 getUserLogin(Email:any ,Password: any){
    return this._http.get('https://localhost:44348/api/Users/login/'+ Email + '/' + Password);
  }
  getDoctors(){
    return this._http.get('https://localhost:44348/api/Doctors');
 }
  updateUser(UserId:any){
    return this._http.put('https://localhost:44348/api/Users/'+ UserId, this.dataService );
  }
  addPatient(){
    return this._http.post('https://localhost:44348/api/Users', this.createUser);
  }
  deleteAccount(UserId:any){
    return this._http.delete( 'https://localhost:44348/api/Users/'+ UserId );
  }
}
