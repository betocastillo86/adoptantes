import { BaseModel } from "./base.model";

export class ReportModel extends BaseModel
{
    name:string;
    email:string;
    description:string;
    friendlyName:string; 
    positive:boolean;
}