import { BaseComponent } from "../base.component";
import { Component, OnInit } from "@angular/core";
import { RoutingService } from "../../services/routing.service";
import { ReportFilterModel } from "../../models/report.filter.model";
import { ActivatedRoute, Params } from "@angular/router";
import { RemoteData, CompleterService, CompleterItem } from "ng2-completer";

@Component({
    selector:'ado-search-reports',
    templateUrl:'search-reports.html'
})
export class SearchReportsComponent extends BaseComponent implements OnInit
{
    filter:ReportFilterModel;
    locationsDatasource:RemoteData;
    selectedLocationName:string;
    showResults:boolean = true;
    
    /**
     *
     */
    constructor(
        routingService:RoutingService,
        private completerService:CompleterService,
        private activatedRoute:ActivatedRoute) {
        super(routingService);
    }

    ngOnInit(): void {


        this.filter = new ReportFilterModel();
        this.filter.page = 0;
        this.filter.pageSize = 9;

        let keyword:string = null;
        this.activatedRoute.queryParams.subscribe((params:Params) => {
            this.filter.locationId = params['locationId'] ? parseInt( params['locationId']) : undefined;
            this.filter.keyword = params['keyword'];
            this.selectedLocationName = params["locationName"];
        });

        this.locationsDatasource =  this.completerService.remote(this.getApiRoute("locations?name="), "name", "name");
	    this.locationsDatasource.dataField("results");
    }

    reloadResults()
    {
        this.showResults = false;

        setTimeout(() => {
            this.showResults = true;
        }, 100);
    }

    locationChanged(selected:CompleterItem)
	{
		if(selected)
		{
			this.filter.locationId = selected.originalObject.id;
            this.selectedLocationName = selected.originalObject.name;
		}
		else
		{
			this.filter.locationId = undefined;
            this.selectedLocationName = undefined;
		}
	}

}