import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../service/user-data.service';

@Component({
  selector: 'app-view-doctors',
  templateUrl: './view-doctors.component.html',
  styleUrls: ['./view-doctors.component.css']
})
export class ViewDoctorsComponent implements OnInit {
  img4:string="../../assets/images/img4.jpg";

  _userService: UserDataService;
  docData: any;

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


  constructor(_userServiceRef: UserDataService) {
    this._userService=_userServiceRef;
   }


  ngOnInit(): void {
    this.ViewDoctors();

  }

}
