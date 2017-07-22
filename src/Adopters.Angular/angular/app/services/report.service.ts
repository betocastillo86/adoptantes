import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { BaseService } from "./base.service";
import 'rxjs/add/operator/map';
import { ReportFilterModel } from "../models/report.filter.model";
import { ReportModel } from "../models/report.model";
import { HttpService } from "./http.service";



@Injectable()
export class ReportService extends BaseService {

  constructor(private http: HttpService) {
    super();
  }

  private getApiRoute(id?:number):string
  {
    return this.getRoute("reports/") + (id !== undefined ? id : "");
  }

  getAll(filter:ReportFilterModel)
  {
    return this.http.get(this.getApiRoute(), { search: filter })
      .map(( res: Response ) => res.json());
  }

  post(model:ReportModel)
  {
      return this.http.post(this.getApiRoute(), model);
  }

}
