import { BaseComponent } from "../base.component";
import { Component, OnInit } from "@angular/core";
import { RoutingService } from "../../services/routing.service";

@Component({
    selector:'ado-new-report',
    templateUrl:'new-report.html'
})
export class NewReportComponent extends BaseComponent implements OnInit
{
	ngOnInit(): void {
		
	}
	/**
	 *
	 */
	constructor(routingService:RoutingService) {
		super(routingService);
	}


}