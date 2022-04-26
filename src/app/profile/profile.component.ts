import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';




@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  img3= "../../assets/images/img3.jpg";
  img4="../../assets/images/img4.jpg";

  _userService:UserDataService;
 userPic:any;
  
  
 constructor( _userServiceRef:UserDataService) { 
    this._userService=_userServiceRef;

  }

  profilePic(){
    if(this._userService.dataService.role==1){
      this.userPic=true;
    }else{
       this.userPic=false;
    }
  }
  

  ngOnInit(): void {
     this.profilePic();
   // this.userdatafromService=this._userService.dataService;
   // console.log(this.userdatafromService);
  }

}
