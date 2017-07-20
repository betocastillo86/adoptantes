import { BaseComponent } from "../base.component";
import { OnInit, Component } from "@angular/core";
import { RoutingService } from "../../services/routing.service";
import { environment } from "../../../environments/environment";
import { Router, ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: 'ado-login',
    templateUrl: 'login.html'
})
export class LoginComponent extends BaseComponent implements OnInit
{
    facebookLink:string;
    returnUrl:string;

    /**
     *
     */
    constructor(private activatedRoute:ActivatedRoute, routingService: RoutingService) {
        super(routingService);
    }

    ngOnInit(): void {
         
        this.activatedRoute.queryParams.subscribe((params:Params) => {
            this.returnUrl = params["returnUrl"];
        });

        let params = new URLSearchParams();
        params.append("response_type", "token");
        params.append("client_id", "1895527400661121");
        let clientId = '1895527400661121'
        
        let redirect_uri=  this.routingService.getFullRoute('externallogin', this.returnUrl);
            
        this.facebookLink = `https://www.facebook.com/v2.5/dialog/oauth?response_type=token&client_id=${clientId}&redirect_uri=${redirect_uri}&display=popup&scope=email&state=undefined`;    
    }


}