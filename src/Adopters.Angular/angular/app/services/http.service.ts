import { Http, RequestOptionsArgs, Response, RequestOptions, Headers } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";

@Injectable()
export class HttpService
{
    private token:string;
    /**
     *
     */
    constructor(private http:Http) {
    }

    get(url:string, options?:RequestOptionsArgs) :Observable<Response>
    {
        options = this.addAuthenticationHeaders(options);
        return this.http.get(url, options);
    }

    post(url:string, body:any, options?:RequestOptionsArgs):Observable<Response>
    {
        options = this.addAuthenticationHeaders(options);
        return this.http.post(url, body, options);
    }

    put(url:string, body:any, options?:RequestOptionsArgs):Observable<Response>
    {
        options = this.addAuthenticationHeaders(options);
        return this.http.post(url, body, options);
    }

    private addAuthenticationHeaders(options?:RequestOptionsArgs) : RequestOptionsArgs
    {
        if(this.token != null)
        {
            if(options == undefined)
            {
                options = {};
            }

            if(options.headers == undefined)
            {
                options.headers = new Headers({'Authorization':'Bearer ' + this.token});
            }
            else
            {
                options.headers.append('Authorization' , 'Bearer ' + this.token );
            }
        }
        
        return options;
    }

    setAuthenticationToken(token:string)
    {
        this.token = token;
    }
}