import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { RoutingService } from "./routing.service";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthGuard implements CanActivate
{
    /**
     *
     */
    constructor(private router:Router, private routingService:RoutingService) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
        
        if(localStorage.getItem("currentUser"))
        {
            return true;
        }

        this.router.navigate([this.routingService.getRoute("login")], { queryParams:{ returnUrl: state.url } });

        return false;
    }

}