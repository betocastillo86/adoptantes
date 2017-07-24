import { BaseComponent } from "../base.component";
import { RoutingService } from "../../services/routing.service";
import { OnInit, Component, ViewChild } from "@angular/core";
import { ReportService } from "../../services/report.service";
import { ActivatedRoute, ParamMap, Params } from "@angular/router";
import { ReportModel } from "../../models/report.model";
import { CommentFilterModel } from "../../models/comment.filter.model";
import { CommentModel } from "../../models/comment.model";
import { CommentService } from "../../services/comment.service";
import { NgForm } from "@angular/forms";

@Component({
    selector: 'ado-report',
    templateUrl: 'report.html'
})
export class ReportComponent extends BaseComponent implements OnInit
{
    //@ViewChild("commentForm")  formComment:NgForm;
    friendlyName:string;
    model:ReportModel;
    filterComments:CommentFilterModel;
    comments:CommentModel[];
    newComment:CommentModel;
    newSubComment:CommentModel;
    showNewSubcommentId:number;
 
    /**
     *
     */
    constructor(
        routingService:RoutingService, 
        private reportService: ReportService,
        private activatedRoute:ActivatedRoute,
        private commentService:CommentService) {

        super(routingService);

        this.filterComments = new CommentFilterModel();
        this.filterComments.pageSize = 10;
        this.filterComments.withChildren = true;

        this.newComment = new CommentModel();
        this.newSubComment = new CommentModel();
    }

    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params:Params) => this.friendlyName = params['friendlyName']);
        this.loadReport();
    }

    loadReport()
    {
        this.reportService.get(this.friendlyName)
            .subscribe(data  => {
                this.model = data.json() as ReportModel;
                this.loadComments();
            });
    }

    loadComments()
    {
        this.filterComments.reportId = this.model.id; 
        this.commentService.getAll(this.filterComments)
            .subscribe(data => this.comments = (data.json()).results as CommentModel[]);
    }

    showAddSubcomment(id:number)
    {
        this.showNewSubcommentId = id;
    }

    saveComment(form:NgForm, parentCommentId?:number)
    {
        if(form.valid)
        {
            let comment = parentCommentId != null ? this.newSubComment : this.newComment;

            if(parentCommentId != null)
            {
                comment.parentCommentId = parentCommentId;
            }
            else
            {
                comment.reportId = this.model.id;   
            }

            
            this.commentService.post(comment)
                .subscribe(data => {
                    this.loadComments();
                    this.newComment = new CommentModel();
                    this.newSubComment = new CommentModel();
                    alert("Gracias por dejar el comentario");
                },
            ex => {
                alert("Ocurrió un error al guardar el comentario");
            } );
        }
    }
}