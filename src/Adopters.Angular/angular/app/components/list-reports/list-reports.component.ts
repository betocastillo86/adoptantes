import { Component, OnInit, Input } from '@angular/core';
import { ReportService } from "../../services/report.service";
import { ReportModel } from "../../models/report.model";
import { ReportFilterModel } from "../../models/report.filter.model";
import { RoutingService } from "../../services/routing.service";
import { BaseComponent } from "../base.component";

@Component({
  selector: 'ado-list-reports',
  templateUrl: 'list-reports.html',
  styles: []
})
export class ListReportsComponent extends BaseComponent implements OnInit {

  @Input() filter:ReportFilterModel;
  private readonly reportService: ReportService;
  reports:ReportModel[];
  hasNextPage:boolean;

  constructor(reportService: ReportService, routingService: RoutingService) { 
    super(routingService);
    this.reportService = reportService;
  }

  ngOnInit() {
    this.getReports();
  }

  getReports()
  {
    this.reportService.getAll(this.filter)
      .subscribe(reponse => {
        this.reports = reponse.results;
        this.hasNextPage= reponse.meta.hasNextPage;
      });
  }

}
