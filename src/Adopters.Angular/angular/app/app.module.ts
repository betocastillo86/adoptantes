import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from "./components/app-routing/app-routing.module";
import { ListReportsComponent } from './components/list-reports/list-reports.component';
import { ReportService } from "./services/report.service";
import { HttpModule } from "@angular/http";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListReportsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [
    ReportService 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { } 
