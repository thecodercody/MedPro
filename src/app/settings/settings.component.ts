import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {
  _userService: UserDataService;
  _route:Router;

  constructor(private _userServiceRef: UserDataService, private _routerRef:Router) {
    this._userService = _userServiceRef;
    this._route=_routerRef;
  }
  //add click to collect all data and then call post 
  updateData(FirstName: any, LastName: any, Email: any, Password: any) {

    this._userService.dataService.firstName = FirstName;
    this._userService.dataService.lastName = LastName;
    this._userService.dataService.email = Email;
    this._userService.dataService.password = Password;
    if (this._userService.dataService.firstName == "" ||
      this._userService.dataService.lastName == "" ||
      this._userService.dataService.email == "" ||
      this._userService.dataService.password == "") {
      window.alert("Please fill out all fields");
    } else {
      this._userService.updateUser(this._userService.dataService.userId).subscribe(
        (data) => {
          console.log(data);
          window.alert("Your profile updated successfully!");
        }, (err) => {
          window.alert("Something went wrong. Please try again");
        })
    }
  }
  deleteUserAccount(){
    this._userService.deleteAccount(this._userService.dataService.userId).subscribe(
      (data)=>{
        window.alert("Your account was deleted");
        this._userService.dataService=null;
        this._route.navigateByUrl('../logIn');
      },(err) => {
        window.alert("Something went wrong. Please try again");
      }
    )
  }


  ngOnInit(): void {
  }

}
