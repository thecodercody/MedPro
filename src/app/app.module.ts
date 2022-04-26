import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateAccountComponent } from './create-account/create-account.component';
// import { HomeComponent } from './home/home.component';
// import { AboutComponent } from './about/about.component';
// import { ContactComponent } from './contact/contact.component';
import { LogInComponent } from './log-in/log-in.component';
import { ProfileComponent } from './profile/profile.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { SettingsComponent } from './settings/settings.component';
import { PortalComponent } from './portal/portal.component';
import { UserDataService } from './service/user-data.service';
import { LogOutComponent } from './log-out/log-out.component';
import { ViewDoctorsComponent } from './view-doctors/view-doctors.component';
import { CreateDoctorComponent } from './create-doctor/create-doctor.component';
import { DoctorsAppointmentComponent } from './doctors-appointment/doctors-appointment.component';


@NgModule({
  declarations: [
    AppComponent,
    CreateAccountComponent,
    // HomeComponent,
    // AboutComponent,
    // ContactComponent,
    LogInComponent,
    ProfileComponent,
    AppointmentsComponent,
    SettingsComponent,
    PortalComponent,
    LogOutComponent,
    ViewDoctorsComponent,
    CreateDoctorComponent,
    DoctorsAppointmentComponent
  ],
  imports: [
 
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [UserDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
