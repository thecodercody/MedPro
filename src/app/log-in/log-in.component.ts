import { JsonPipe, NgForOf } from '@angular/common';
import { Component, ErrorHandler, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  _userService: UserDataService;
  _router:Router;
  public userdata: any;
  // logIn: boolean = false;
  

  constructor(private _userServiceRef: UserDataService,private routerRef:Router) {
    this._userService = _userServiceRef;
    this._router= routerRef;
  }

  storeUserData(Email: any, Password: any) {
    this._userService.getUserLogin(Email, Password).subscribe(
      (data) => {

        this.userdata = data;

        if (this.userdata != null) {
          console.log("if works");
          console.log(this.userdata);
          // this.logIn = true;
          // console.log(this.logIn);

          this._userService.dataService = this.userdata;
          this._userService.isLoginService = true;
          console.log(this._userService.dataService + "this one works");
          this._router.navigateByUrl('/portal/profile');
        }// }else{
        //   window.alert("Smth went wrong");
        // }
      }, (err) => {
        if (err.status == 404) {
          window.alert("Please anter email and password");
        }
        else if (err.status == 500) {
          window.alert("Invalid email or password");
        }else if(err.status == 400){
          window.alert("Invalid  password");
        }

      }

    )
    // this._userService.dataService = this.userdata;
    // this._userService.isLoginService = this.logIn;
  }


  ngOnInit(): void {
  }

}
