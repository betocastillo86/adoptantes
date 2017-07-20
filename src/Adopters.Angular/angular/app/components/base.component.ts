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

    getImage(path:string):string
    {
        return this.routingService.getImage(path);
    }
}
