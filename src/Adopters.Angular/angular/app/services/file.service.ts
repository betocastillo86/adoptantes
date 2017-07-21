import { BaseService } from "./base.service";
import { HttpService } from "./http.service";
import { RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import 'rxjs/add/operator/map';

@Injectable()
export class FileService extends BaseService
{
    /**
     *
     */
    constructor(private http:HttpService) {
        super();
    }

    post(file:any, name?:string)
    {
        let formData = new FormData();
        formData.append('files', file);
        formData.append('name', name ? name : file.name);

        let params = new RequestOptions({
            body: formData
        });

        return this.http.post(this.getRoute('files'), {}, params)
            .map((res: Response ) => res.json()); 
    }
}