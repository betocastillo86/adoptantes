export class HelperService
{
    /**
     *
     */
    constructor() {
        
    }

    queryStringToJson(queryString:string) : any
    {
        var pairs = queryString.slice(1).split('&');

        var result = {};
        pairs.forEach(function (pair:string) {
            let values = pair.split('=');
            result[values[0]] = decodeURIComponent(values[1] || '');
        });

        return JSON.parse(JSON.stringify(result));
    }
}