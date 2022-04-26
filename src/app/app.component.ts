import { Component } from '@angular/core';
import { UserDataService } from './service/user-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'medProProject2';
  _userService: UserDataService;


  constructor(private _userServiceRef: UserDataService) {
    this._userService = _userServiceRef;
   
  }
}
 

