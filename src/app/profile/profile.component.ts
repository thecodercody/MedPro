import { Component, OnInit } from '@angular/core';
import {LogInComponent} from '../log-in/log-in.component';
import { UserDataService } from '../service/user-data.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  img3:string = "../../assets/images/img3.jpg";

  _userService:UserDataService;
 // userdatafromService:any;
  
  
 constructor( _userServiceRef:UserDataService) { 
    this._userService=_userServiceRef;

  }
  //userdata2:any= this._userService2.dataService;
  

  ngOnInit(): void {
   // this.userdatafromService=this._userService.dataService;
   // console.log(this.userdatafromService);
  }

}
