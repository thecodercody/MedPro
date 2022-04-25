import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateAccountComponent } from './create-account/create-account.component';
// import { HomeComponent } from './home/home.component';
// import { AboutComponent } from './about/about.component';
// import { ContactComponent } from './contact/contact.component';
import { LogInComponent } from './log-in/log-in.component';
//import { ProfileComponent } from './profile/profile.component';
//import { AppointmentsComponent } from './appointments/appointments.component';
//import { SettingsComponent } from './settings/settings.component';
import { PortalComponent } from './portal/portal.component';
import { UserDataService } from './service/user-data.service';

@NgModule({
  declarations: [
    AppComponent,
    CreateAccountComponent,
    // HomeComponent,
    // AboutComponent,
    // ContactComponent,
    LogInComponent,
    //ProfileComponent,
    //AppointmentsComponent,
    //SettingsComponent,
    PortalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [UserDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
