import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-create-doctor',
  templateUrl: './create-doctor.component.html',
  styleUrls: ['./create-doctor.component.css']
})
export class CreateDoctorComponent implements OnInit {

  _userService: UserDataService;

  constructor(_userServiceRef: UserDataService) {
    this._userService = _userServiceRef;

  }

  createNewDoc(FirstName: any, LastName: any, Email: any, Password: any) {
    this._userService.createDoc.firstName = FirstName;
    this._userService.createDoc.lastName = LastName;
    this._userService.createDoc.email = Email;
    this._userService.createDoc.password = Password;
    if (this._userService.createDoc.firstName == "" ||
      this._userService.createDoc.lastName == "" ||
      this._userService.createDoc.email == "" ||
      this._userService.createDoc.password == ""
    ) {
      window.alert("Please fill out all fields");
    } else {
      this._userService.addDoc().subscribe(
        (data) => {
          window.alert("Account created successfully!");

        }, (err) => {
          window.alert("Something went wrong. Please try again");
        }
      )
    }
  }



  ngOnInit(): void {
  }

}
