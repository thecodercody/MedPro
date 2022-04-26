import { Component, OnInit } from '@angular/core';

// import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-portal',
  templateUrl: './portal.component.html',
  styleUrls: ['./portal.component.css']
})
export class PortalComponent implements OnInit {
  _userService: UserDataService;
  isDoctor:any;

  constructor(  _userServiceRef: UserDataService) {
    this._userService=_userServiceRef;
  }
   check(){
    if(this._userService.dataService.role==1){
     this.isDoctor=false;
    }else{
      this.isDoctor=true;
    }
  }
  
  ngOnInit(): void {
    this.check();

    
  }

}
