import { BaseService } from "./base.service";

export class RoutingService extends BaseService
{
    getRoute(key:string, ...params:string[]) : string
    {
        switch (key) {
            case "reports":
                return "/reportados";
            case "newreport":
                return "/reportar";
            case "login":
                return "/registrarse";
            case "externallogin":
                return "/externallogin?returnUrl="+params[0];
            case "report":
                return "/reportado/"+ params[0];
            default:
            return "/";
        } 
    }

    getImage(path:string) : string
    {
        return this.siteUrl + path; 
    }

    getApiRoute(path:string):string
    {
        return this.baseApi + path;
    }

    getFullRoute(key:string, ...params:string[]) : string
    {
        return 'http://localhost:4200/' + this.getRoute(key, ...params);
    }
}
