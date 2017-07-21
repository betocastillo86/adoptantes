import { BaseComponent } from "../base.component";
import { Component, OnInit } from "@angular/core";
import { RoutingService } from "../../services/routing.service";
import { RemoteData, CompleterService } from "ng2-completer";
import { ReportModel } from "../../models/report.model";
import { FileModel } from "../../models/file.model";
//import { RemoteData } from "ng2-completer";

@Component({
    selector:'ado-new-report',
    templateUrl:'new-report.html'
})
export class NewReportComponent extends BaseComponent implements OnInit
{
	//private dataLocations:RemoteData;
	
	locationsDatasource:RemoteData;
	model:ReportModel;

	ngOnInit(): void {
		this.locationsDatasource =  this.completerService.remote(this.getApiRoute("locations?name="), "name", "name");
		this.locationsDatasource.dataField("results");

		this.model = new ReportModel();
	}

	/**
	 *
	 */
	constructor(routingService:RoutingService, private completerService:CompleterService) {
		super(routingService);
	}


	changePositive(newValue:boolean)
	{
		this.model.positive = newValue;
	}

	fileCompleted(fileModel:FileModel)
	{
		console.log("El archivo fue correctamente cargado", fileModel);
	}

}