import { UserAuthenticationModel } from "../models/user.authentication.model";
import { HttpService } from "./http.service";
import { Injectable } from "@angular/core";

@Injectable()
export class MainService
{
    currentUser:UserAuthenticationModel;

    /**
     *
     */
    constructor(private httpService:HttpService) {
    }

    validateSession() : UserAuthenticationModel
    {
        if(localStorage.getItem("currentUser"))
        {
            this.currentUser = JSON.parse(localStorage.getItem("currentUser")) as UserAuthenticationModel;
            this.httpService.setAuthenticationToken(this.currentUser.token.accessToken);
        }
        else
        {
            this.currentUser = null;
            this.httpService.setAuthenticationToken(null);
        }

        return this.currentUser;
    }

    logout() : UserAuthenticationModel
    {
        localStorage.removeItem("currentUser");
        return this.validateSession();
    }
}