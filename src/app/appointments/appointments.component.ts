import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {
  _userService:UserDataService;

  // calendar:any;
  // timeForm:any;
  // docIdForm:any;


  docData: any;
  appointmentData:any;

  ViewDoctors(){
    this._userService.getDoctors().subscribe(
      (data)=>{
        this.docData=data;
        if (this.docData!=""){
          console.log(this.docData);
          this._userService.docsData=this.docData;

        } 
      }
    )
  }

  AppointmentHistory(){
    this._userService.displayPatientsApp(this._userService.dataService.userId).subscribe(
      (data)=>{
        this.appointmentData=data;
        this._userService.appointmentData=this.appointmentData;
      }

    )
  }


  constructor( _userServiceRef:UserDataService) { 
    this._userService=_userServiceRef;
  
  }
  formData(date:any,time:any, docId:any){
    this._userService.calendar=date;
    this._userService.timeForm=time;
    this._userService.docIdForm=docId;
    console.log(this._userService.calendar,this._userService.timeForm,this._userService.docIdForm);
    if (this._userService.calendar == "" ||
    this._userService.timeForm == "" ||
    this._userService.docIdForm== "" 
  ) {
    window.alert("Please fill out all fields");
  } else {
    this._userService.dateTime=this._userService.calendar + " " +this._userService.timeForm;
    this._userService.addAppointment().subscribe(
        (data) => {
          window.alert("Your appointment was created successfully!");
        }, (err) => {
          window.alert("Time unavailable");
        }
      )


  }
  }

  ngOnInit(): void { 
    this.ViewDoctors();
    this.AppointmentHistory();
  }

}
