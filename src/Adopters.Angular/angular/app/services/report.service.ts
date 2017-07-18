import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { BaseService } from "./base.service";
import 'rxjs/add/operator/map';
import { ReportFilterModel } from "../models/report.filter.model";



@Injectable()
export class ReportService extends BaseService {

  constructor(private http: Http) {
    super();
  }

  getAll(filter:ReportFilterModel)
  {
    return this.http.get(this.getRoute("reports"))
      .map(( res: Response ) => res.json());
  }

}
