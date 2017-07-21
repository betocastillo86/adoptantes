import { Component } from '@angular/core';
import { BaseComponent } from "./components/base.component";
import { RoutingService } from "./services/routing.service";
import { UserAuthenticationModel } from "./models/user.authentication.model";
import { HttpService } from "./services/http.service";
import { MainService } from "./services/main.service";

@Component({
  selector: 'ado-root',
  templateUrl: 'app.html',
  styles: []
})
export class AppComponent extends BaseComponent {
  currentUser:UserAuthenticationModel;
  
  /**
   *
   */
  constructor(private mainService:MainService, routingService:RoutingService) {
    super(routingService);
    this.validateAuthentication();
  }

  logout()
  {
    this.currentUser = this.mainService.logout();
  }

  private validateAuthentication()
  {
     this.currentUser = this.mainService.validateSession();
  }
}
