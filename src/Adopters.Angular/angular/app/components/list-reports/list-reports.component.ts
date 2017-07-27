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
  @Input() enablePaging:boolean;

  private readonly reportService: ReportService;
  reports:ReportModel[];
  hasNextPage:boolean;
  showNextPage:boolean;

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

      let records = reponse.results as ReportModel[];

      if(!this.reports)
      {
        this.reports = records;
      }
      else
      {
        this.reports = this.reports.concat(records);
      }

        
        this.hasNextPage= reponse.meta.hasNextPage;
        this.showNextPage = this.enablePaging && this.hasNextPage;
      });
  }

  nextPage()
  {
    this.filter.page++;
    this.getReports();
  }

}
