import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "../home/home.component";
import { NewReportComponent } from "../new-report/new-report.component";
import { LoginComponent } from "../login/login.component";
import { LoginExternalComponent } from "../login-external/login-external.component";
import { AuthGuard } from "../../services/auth.guard";

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'reportar', component: NewReportComponent/*, canActivate: [AuthGuard]*/ },
  { path: 'registrarse', component: LoginComponent },
  { path: 'externallogin', component: LoginExternalComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports:[
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule 
{ 
  
}
