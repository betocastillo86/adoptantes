import { environment } from '../../environments/environment';

export class BaseService
{
    protected baseApi: string;
    protected siteUrl: string;

    /**
     *
     */
    constructor() {
        this.baseApi = environment.apiUrl;
        this.siteUrl = environment.siteUrl;
    }

    protected getRoute(complement:string) : string
    {
        return this.baseApi + complement;
    }
}