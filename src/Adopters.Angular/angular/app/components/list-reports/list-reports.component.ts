import { Component, OnInit, Input } from '@angular/core';
import { ReportService } from "../../services/report.service";
import { ReportModel } from "../../models/report.model";
import { ReportFilterModel } from "../../models/report.filter.model";

@Component({
  selector: 'ado-list-reports',
  templateUrl: 'list-reports.html',
  styles: []
})
export class ListReportsComponent implements OnInit {

  @Input() filter:ReportFilterModel;
  private readonly reportService: ReportService;
  reports:ReportModel[];
  hasNextPage:boolean;

  constructor(reportService: ReportService) { 
    this.reportService = reportService;
  }

  ngOnInit() {
    this.getReports();
  }

  getReports()
  {
    var report =new ReportModel();
    report.name = "fasdfsdafasd";
    this.reports = [ report];

    this.reportService.getAll(this.filter)
      .subscribe(reponse => {
        this.reports = reponse.results;
        this.hasNextPage= reponse.meta.hasNextPage;
      });
  }

}
