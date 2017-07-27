import { BaseModel } from "./base.model";
import { FileModel } from "./file.model";
import { LocationModel } from "./location.model";
import { UserModel } from "./user.model";

export class ReportModel extends BaseModel
{
    /**
     *
     */
    constructor() {
        super();
        this.location = new LocationModel();
    }

    name:string;
    email:string;
    description:string;
    friendlyName:string; 
    positive:boolean;
    image:FileModel;
    location:LocationModel;
    user:UserModel;
    facebookProfile:string;
    twitterProfile:string;
}