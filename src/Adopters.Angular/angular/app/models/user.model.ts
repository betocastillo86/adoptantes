import { BaseModel } from "./base.model";

export class UserModel extends BaseModel
{
    name:string;
    facebookId:string;
    email:string;
    
    public facebookUrl() :string{
        return "http://www.facebook.com/"+this.facebookId;
    }
}