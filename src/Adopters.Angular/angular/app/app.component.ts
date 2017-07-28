import { Component, OnInit, HostListener, Inject } from '@angular/core';
import { BaseComponent } from "./components/base.component";
import { RoutingService } from "./services/routing.service";
import { UserAuthenticationModel } from "./models/user.authentication.model";
import { HttpService } from "./services/http.service";
import { MainService } from "./services/main.service";
import { DOCUMENT, Title } from "@angular/platform-browser";
import { Location } from '@angular/common';
import { Router, ActivatedRoute, NavigationEnd } from "@angular/router";
import { SeoService } from "./services/seo.service";
import { environment } from "../environments/environment";

declare var ga:Function;

@Component({
  selector: 'ado-root',
  templateUrl: 'app.html',
  styles: []
})
export class AppComponent extends BaseComponent implements OnInit {
  
  currentUser: UserAuthenticationModel;
  navIsFixed: boolean = false;
  isHome:boolean = false;
  displayMenu?:string;
  
  seoTitle:string;
  seoDescription:string;
  analyticsEnabled:boolean;
  analyticsCode:string;
  
  /**
   *
   */
  constructor(private mainService:MainService, 
   routingService:RoutingService,
    @Inject(DOCUMENT) private document: Document,
    private router:Router,
    private location:Location) {
    
    super(routingService);
    this.validateAuthentication();
    this.analyticsEnabled = environment.enableAnalytics;
    this.analyticsCode = environment.analyticsCode;

    this.router.events.subscribe((ev) => {
      if(ev instanceof NavigationEnd)
      {
        this.registerAnalytics();
      }
    });

    
  }

  ngOnInit(): void {
    ///No hacerlo así. No es buena idea
    this.router.events.subscribe((val) => {
      this.isHome = location.pathname == '/';
      this.navIsFixed = !this.isHome;
      this.validateAuthentication();
      //this.registerAnalytics();
    });

    
  }


  @HostListener("window:scroll", [])
  onWindowScroll() {

    if(this.isHome)
    {
      let number = this.document.body.scrollTop;
        if (number > 100) {
          this.navIsFixed = true;
        } else if (this.navIsFixed && number < 50) {
          this.navIsFixed = false;
        }
    }
  }

  logout() 
  {
    this.currentUser = this.mainService.logout();
  }

  toggleMenu()
  {
    this.displayMenu = this.displayMenu == undefined || this.displayMenu == 'none' ? 'block' : 'none';
  }

  hideMenu()
  {
    if(this.displayMenu != undefined)
    {
      this.displayMenu = 'none';
    }
  }

  registerAnalytics()
  {
    if(this.analyticsEnabled)
    {
        ga('send', 'pageview');
    }
    else
    {
      console.log("Page view trackeado");
    }
  }

  private validateAuthentication()
  {
     this.currentUser = this.mainService.validateSession();
  }
}
