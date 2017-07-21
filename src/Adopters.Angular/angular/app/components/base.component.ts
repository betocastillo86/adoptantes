import { RoutingService } from "../services/routing.service";

export class BaseComponent
{
    /**
     *
     */
    constructor(protected routingService:RoutingService) {
    }

    getRoute(key:string, ...params:string[]) : string
    {
        return this.routingService.getRoute(key, ...params);
    }

    getApiRoute(key:string) : string
    {
        return this.routingService.getApiRoute(key);
    }

    getImage(path:string):string
    {
        return this.routingService.getImage(path);
    }
}
