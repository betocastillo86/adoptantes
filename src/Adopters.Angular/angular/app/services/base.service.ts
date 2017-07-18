import { environment } from '../../environments/environment';

export class BaseService
{
    protected baseApi: string;

    /**
     *
     */
    constructor() {
        this.baseApi = environment.apiUrl;
    }

    protected getRoute(complement:string) : string
    {
        return this.baseApi + complement;
    }
}