import { BaseService } from "./base.service";
import { Http, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import { ExternalAuthenticationModel } from "../models/external.authentication.model";
import { AuthenticationTokenModel } from "../models/token.model";
import 'rxjs/add/operator/map';
import { UserAuthenticationModel } from "../models/user.authentication.model";
import { HttpService } from "./http.service";

@Injectable()
export class AuthenticationService extends BaseService
{
    token:string;

    /**
     *
     */
    constructor(private http:HttpService) {
        super();
    }

    postExternal(model:ExternalAuthenticationModel)
    {
        return this.http.post(this.getRoute("auth/external"), model)
            .map((res: Response) => {
                var user = res.json() as UserAuthenticationModel;
                return user;
            });
    }

}