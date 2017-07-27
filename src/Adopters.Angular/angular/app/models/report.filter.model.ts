import { BaseFilterModel } from "./base.filter.model";

export class ReportFilterModel extends BaseFilterModel
{
    keyword?:string;
    locationId?:number;
}