import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class UserDataService implements CanActivate{
  _http:HttpClient;

  dataService:any;
  docsData:any;
  isLoginService:any=false;
  calendar:any;
  timeForm:any;
  docIdForm:any;
  dateTime:any;
  appointmentData:any;


  createUser:any  = { 
    firstName:"", 
    lastName:"",
    email:"",
    password:"",
    role:1
  };
  createDoc:any  = { 
    firstName:"", 
    lastName:"",
    email:"",
    password:"",
    role:2
  }; 

  constructor(private _httpRef : HttpClient) {
    this._http = _httpRef;
   }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {
    if(this.isLoginService == true){
        return true;
    }else{
      return false;
    }
  }


 getUserLogin(Email:any ,Password: any){
    return this._http.get('https://localhost:44348/api/Users/login/'+ Email + '/' + Password);
  }
  getDoctors(){
    return this._http.get('https://localhost:44348/api/Users/doc');
 }
  updateUser(UserId:any){
    return this._http.put('https://localhost:44348/api/Users/'+ UserId, this.dataService );
  }
  addPatient(){
    return this._http.post('https://localhost:44348/api/Users', this.createUser);
  }
  addDoc(){
    return this._http.post('https://localhost:44348/api/Users', this.createDoc);
  }
  deleteAccount(UserId:any){
    return this._http.delete( 'https://localhost:44348/api/Users/'+ UserId );
  }

  addAppointment(){
    return this._http.post('https://localhost:44348/api/Appointments/MakeAppointment/'+ this.dataService.userId + '/' + this.docIdForm +'/' + this.dateTime, { title: 'Angular POST Request Example' });
  }
 
  displayPatientsApp(UserId:any){
    return this._http.get('https://localhost:44348/api/Appointments/patient/'+ UserId);
  }
  displayDoctorsApp(UserId:any){
    return this._http.get('https://localhost:44348/api/Appointments/doctor/'+ UserId);
  }

}
