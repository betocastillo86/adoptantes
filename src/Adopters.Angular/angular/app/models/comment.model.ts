import { BaseModel } from "./base.model";
import { UserModel } from "./user.model";

export class CommentModel extends BaseModel
{
    value:string;
    countSubcomments:number;
    creationDate:Date;
    user:UserModel;
    reportId?:number;
    parentCommentId?:number;
    canDelete:boolean;
    firstComments:CommentModel[];
}