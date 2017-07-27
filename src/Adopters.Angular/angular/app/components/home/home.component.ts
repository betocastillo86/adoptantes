import { Component, OnInit } from '@angular/core';
import { ReportFilterModel } from "../../models/report.filter.model";
import { BaseComponent } from "../base.component";
import { RoutingService } from "../../services/routing.service";
import { SeoService } from "../../services/seo.service";

@Component({
  selector: 'ado-home',
  templateUrl: 'home.html',
  styles: []
})
export class HomeComponent extends BaseComponent implements OnInit {

  filterReports:ReportFilterModel;
  keywordSearch:string;

  constructor(routingService: RoutingService, 
    private seoService:SeoService) { 
    super(routingService);
  }

  ngOnInit() {
    this.filterReports = {
      pageSize:12
    };

    this.seoService.setGeneralSeo("Adoptante - Valida si la persona que quiere adoptar es buena o mala adoptante", "Muchas veces no sabes si la persona que quiere adoptar a tu huellita es buena o mala. Por eso en adoptante.com puedes validar o registrar aquellas personas que tienen historial en la adopción de perros o gatos");
  }

}
