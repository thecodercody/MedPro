import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {
  _userService: UserDataService;
  _router: Router;
  constructor(_userServiceRef: UserDataService, routerRef: Router) {
    this._userService = _userServiceRef;
    this._router = routerRef;
  }

  createNewUser(FirstName: any, LastName: any, Email: any, Password: any) {
    this._userService.createUser.firstName = FirstName;
    this._userService.createUser.lastName = LastName;
    this._userService.createUser.email = Email;
    this._userService.createUser.password = Password;
    if (this._userService.createUser.firstName == "" ||
      this._userService.createUser.lastName == "" ||
      this._userService.createUser.email == "" ||
      this._userService.createUser.password == ""
    ) {
      window.alert("Please fill out all fields");
    } else {
      this._userService.addPatient().subscribe(
        (data) => {
          window.alert("Your account created successfully!");
          this._router.navigateByUrl('/logIn');
        }, (err) => {
          window.alert("Something went wrong. Please try again");
        }
      )
    }
  }


  ngOnInit(): void {
  }

}
