import { BaseComponent } from "../base.component";
import { Component, OnInit, ViewChild } from "@angular/core";
import { RoutingService } from "../../services/routing.service";
import { RemoteData, CompleterService, CompleterItem } from "ng2-completer";
import { ReportModel } from "../../models/report.model";
import { FileModel } from "../../models/file.model";
import { NgForm } from "@angular/forms";
import { ReportService } from "../../services/report.service";
import { Router } from "@angular/router";
//import { RemoteData } from "ng2-completer";

@Component({
    selector:'ado-new-report',
    templateUrl:'new-report.html'
})
export class NewReportComponent extends BaseComponent implements OnInit
{
	//private dataLocations:RemoteData;
	
	@ViewChild("reportForm") reportForm:NgForm;

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
	constructor(
		routingService:RoutingService,
		private completerService:CompleterService, 
		private reportService:ReportService,
		private router:Router) {
		super(routingService);
	}


	changePositive(newValue:boolean)
	{
		this.model.positive = newValue;
	}

	imageCompleted(fileModel:FileModel)
	{
		this.model.image = fileModel;
		console.log("El archivo fue correctamente cargado", fileModel);
	}

	locationChanged(selected:CompleterItem)
	{
		if(selected)
		{
			this.model.location.id = selected.originalObject.id;
		}
		else
		{
			this.model.location.id = 0;
		}
	}

	save()
	{
		if(this.reportForm.valid)
		{
			this.reportService.post(this.model)
			.subscribe(data => {
				this.confirmSaved(data)
			},
			err => {
				console.log(err);
			});
		}
	}

	private confirmSaved(data:any)
	{
		alert("Gracias por dejar tu reporte");
		this.router.navigate([this.getRoute("home")]);
	}

}