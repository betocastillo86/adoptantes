import { Component, OnInit } from '@angular/core';
import { ReportFilterModel } from "../../models/report.filter.model";
import { BaseComponent } from "../base.component";
import { RoutingService } from "../../services/routing.service";

@Component({
  selector: 'ado-home',
  templateUrl: 'home.html',
  styles: []
})
export class HomeComponent extends BaseComponent implements OnInit {

  filterReports:ReportFilterModel;

  constructor(routingService: RoutingService) { 
    super(routingService);
  }

  ngOnInit() {
    this.filterReports = {
      pageSize:12
    };
  }

}
