import { BaseComponent } from "../base.component";
import { RoutingService } from "../../services/routing.service";
import { OnInit, Component, ViewChild } from "@angular/core";
import { ReportService } from "../../services/report.service";
import { ActivatedRoute, ParamMap, Params, Router } from "@angular/router";
import { ReportModel } from "../../models/report.model";
import { CommentFilterModel } from "../../models/comment.filter.model";
import { CommentModel } from "../../models/comment.model";
import { CommentService } from "../../services/comment.service";
import { NgForm } from "@angular/forms";
import { MainService } from "../../services/main.service";
import { SeoService } from "../../services/seo.service";

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
    isThereMoreComments:boolean;
    isLoggedIn:boolean;
    returnUrl:any;
 
    /**
     *
     */
    constructor(
        routingService:RoutingService, 
        private reportService: ReportService,
        private activatedRoute:ActivatedRoute,
        private commentService:CommentService,
        private mainService:MainService,
        private router:Router,
        private seoService:SeoService) {

        super(routingService);

        this.filterComments = new CommentFilterModel();
        this.filterComments.pageSize = 10;
        this.filterComments.page = 0;
        this.filterComments.withChildren = true;

        this.newComment = new CommentModel();
        this.newSubComment = new CommentModel();
    }

    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params:Params) => this.friendlyName = params['friendlyName']);
        this.loadReport();
        console.log(this.mainService.currentUser);
        this.isLoggedIn = this.mainService.currentUser != undefined;
        this.returnUrl = {returnUrl:this.router.url};
    }

    loadReport()
    {
        this.reportService.get(this.friendlyName)
            .subscribe(data  => {
                this.model = data.json() as ReportModel;

                this.seoService.setGeneralSeo(this.model.name + " - Valida si es un buen(a) adoptante o no para tu perro o gato", this.model.description);

                this.loadComments();
            });
    }

    loadComments()
    {
        this.filterComments.reportId = this.model.id; 
        this.commentService.getAll(this.filterComments)
            .subscribe(data => {
                let response = data.json();

                let commentsPage = (response).results as CommentModel[];
                
                if(this.filterComments.page == 0)
                {
                    this.comments = commentsPage;
                }
                else
                {
                    this.comments = this.comments.concat(commentsPage);
                }
                
                this.isThereMoreComments = response.meta.hasNextPage;
            });
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
                    this.filterComments.page = 0;
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

    showMoreComments()
    {
        this.filterComments.page++;
        this.loadComments();
    }
}