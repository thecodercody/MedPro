import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-log-out',
  templateUrl: './log-out.component.html',
  styleUrls: ['./log-out.component.css']
})
export class LogOutComponent implements OnInit {
  _userService: UserDataService;
  _router: Router;

  constructor(_userServiceRef:UserDataService, private _routerRef:Router) { 
    this._router=_routerRef;
    this._userService=_userServiceRef;
    this._userService.dataService="";
    this._userService.isLoginService=false;
    
    console.log(this._userService.isLoginService,this._userService.dataService);
    this._router.navigateByUrl('/home');
   
  }

  ngOnInit(): void {
  }

}
