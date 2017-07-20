import { BaseComponent } from "../base.component";
import { OnInit, Component } from "@angular/core";
import { RoutingService } from "../../services/routing.service";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { AuthenticationService } from "../../services/authentication.service";
import { HelperService } from "../../services/helper.service";
import { ExternalAuthenticationModel } from "../../models/external.authentication.model";
import { AuthenticationTokenModel } from "../../models/token.model";
import { MainService } from "../../services/main.service";
///import { ROUTER_PROVIDERS } from "@angular/router/src/router_module";

@Component({
    selector:'ado-external-login',
    template:''
})
export class LoginExternalComponent extends BaseComponent implements OnInit 
{
    private externalResponse:any;

    private model:ExternalAuthenticationModel;

    public token:string;

    public returnUrl:string;

    /** 
     * 
     */ 
    constructor(
        private router:Router, 
        private activatedRoute:ActivatedRoute, 
        private authenticationService:AuthenticationService, 
        private helperService: HelperService,
        private mainService: MainService,
        routingService:RoutingService) {
        super(routingService);
    }

    ngOnInit(): void {
        this.activatedRoute.fragment.subscribe((fragment:string) => {
            this.externalResponse = this.helperService.queryStringToJson(fragment);
            this.sendFacebookResponse();
        });

        this.activatedRoute.queryParams.subscribe((params:Params) => {
            this.returnUrl = params['returnUrl'];
        });
    }

    sendFacebookResponse() :void
    {
        this.model = new ExternalAuthenticationModel();
        this.model.socialNetwork = "Facebook";
        this.model.token = this.externalResponse.access_token;
        this.authenticationService.postExternal(this.model)
            .subscribe((response) => {
              localStorage.setItem("currentUser", JSON.stringify(response));
              this.mainService.validateSession();
              this.router.navigate([this.returnUrl ? this.returnUrl : ""]);
            },
            err => {
                debugger;
                console.log("Error intentando actualizar");
            })
            data => {
                debugger;
                console.log(data);
            };
    }

}