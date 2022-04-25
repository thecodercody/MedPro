import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {
  _userService:UserDataService;

  constructor( _userServiceRef:UserDataService) { 
    this._userService=_userServiceRef;

  }

  ngOnInit(): void { 
  }

}
