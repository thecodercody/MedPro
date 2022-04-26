import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { ContactComponent } from './contact/contact.component';
import { CreateAccountComponent } from './create-account/create-account.component';
import { HomeComponent } from './home/home.component';
import { LogInComponent } from './log-in/log-in.component';
import { LogOutComponent } from './log-out/log-out.component';
import { PortalComponent } from './portal/portal.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDataService } from './service/user-data.service';
import { SettingsComponent } from './settings/settings.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ViewDoctorsComponent } from './view-doctors/view-doctors.component';
import { CreateDoctorComponent } from './create-doctor/create-doctor.component';
import { DoctorsAppointmentComponent } from './doctors-appointment/doctors-appointment.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'home', component: HomeComponent},
  {path:'about', component: AboutComponent},
  {path:'contact', component: ContactComponent},
  {path:'logIn', component: LogInComponent},
  //children:[{path:'createAccount', component:CreateAccountComponent}]
  {path:'portal', component: PortalComponent,canActivate:[UserDataService],
    children:[
      {path:'profile', component:ProfileComponent},
      {path:'appointments', component: AppointmentsComponent},
      {path:'doctorsAppointments', component:DoctorsAppointmentComponent},
      {path:'settings', component:SettingsComponent},
      {path:'viewDoctors', component:ViewDoctorsComponent},
      {path:'createDoctorsAccount', component:CreateDoctorComponent},
      {path:'logOut', component:LogOutComponent}
      
    ],
  },

  {path:'createAccount', component:CreateAccountComponent},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes), 
    CommonModule,
    BrowserModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
