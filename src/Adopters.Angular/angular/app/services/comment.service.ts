import { BaseService } from "./base.service";
import { CommentFilterModel } from "../models/comment.filter.model";
import { HttpService } from "./http.service";
import { Injectable } from "@angular/core";
import { CommentModel } from "../models/comment.model";

@Injectable()
export class CommentService extends BaseService
{
    /**
     *
     */
    constructor(private http:HttpService) {
        super();
    }

    getAll(filter:CommentFilterModel)
    {
        return this.http.get(this.getRoute("comments"), { search: filter });
    }

    post(model:CommentModel)
    {
        return this.http.post(this.getRoute("comments"), model);
    }
}