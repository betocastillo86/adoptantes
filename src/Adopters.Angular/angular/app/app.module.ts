import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from "./components/app-routing/app-routing.module";
import { ListReportsComponent } from './components/list-reports/list-reports.component';
import { ReportService } from "./services/report.service";
import { RoutingService } from "./services/routing.service";
import { HttpModule } from "@angular/http";
import { NewReportComponent } from "./components/new-report/new-report.component";
import { LoginComponent } from "./components/login/login.component";
import { LoginExternalComponent } from "./components/login-external/login-external.component";
import { AuthenticationService } from "./services/authentication.service";
import { HelperService } from "./services/helper.service";
import { HttpService } from "./services/http.service";
import { MainService } from "./services/main.service";
import { AuthGuard } from "./services/auth.guard";
import {Ng2CompleterModule} from "ng2-completer";
import { UploadFileDirective } from './directives/upload-file.directive';
import { FileService } from "./services/file.service";
import { FormsModule } from "@angular/forms";
import { ReportComponent } from "./components/report/report.component";
import { CommentService } from "./services/comment.service";

//import { environment } from '../environments/environment'
  
//environment.siteUrl + 

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListReportsComponent,
    NewReportComponent,
    LoginComponent,
    LoginExternalComponent,
    UploadFileDirective,
    ReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    Ng2CompleterModule,
    FormsModule
  ],
  providers: [
    ReportService,
    RoutingService,
    AuthenticationService,
    HelperService,
    HttpService,
    MainService,
    AuthGuard,
    FileService,
    CommentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { } 
