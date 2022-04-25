import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';
@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})
export class HomeComponent implements OnInit {
  img1:string = "../../assets/images/img1.png";
  img2:string = "../../assets/images/img2.png";
  img3:string = "../../assets/images/img3.png";

  _userService2:UserDataService;
  allDoctors:any;
  constructor(_userServiceRef2:UserDataService) { 
     this._userService2=_userServiceRef2;  
   }
   getDoctorsMethod(){
      this._userService2.getDoctors().subscribe((data)=>
      {
        this.allDoctors =data;
      }
      )
   }

  ngOnInit(): void {
  }

}
