import { BaseModel } from "./base.model";
import { AuthenticationTokenModel } from "./token.model";
import { LocationModel } from "./location.model";

export class UserAuthenticationModel extends BaseModel
{
    email:string;
    name:string;
    id:number;
    token:AuthenticationTokenModel;
    facebookId:string;
    role:string;
    location:LocationModel;
}