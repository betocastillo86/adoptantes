import { BaseFilterModel } from "./base.filter.model";

export class CommentFilterModel extends BaseFilterModel
{
    keyword:string;
    userId?:number;
    reportId?:number;
    parentId?:number;
    withChildren:boolean;
}