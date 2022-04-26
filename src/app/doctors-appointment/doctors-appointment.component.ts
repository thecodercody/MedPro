import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-doctors-appointment',
  templateUrl: './doctors-appointment.component.html',
  styleUrls: ['./doctors-appointment.component.css']
})
export class DoctorsAppointmentComponent implements OnInit {
  _userService:UserDataService;
  appointmentData:any;

  doctorAppointments(){
    this._userService.displayDoctorsApp(this._userService.dataService.userId).subscribe(
      (data)=>{
        this.appointmentData=data;
        this._userService.appointmentData=this.appointmentData;
      }

    )
  }

  constructor( _userServiceRef:UserDataService) { 
    this._userService=_userServiceRef;
  
  }

  ngOnInit(): void {
    this.doctorAppointments();
  }

}
