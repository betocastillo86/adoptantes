import { BaseService } from "./base.service";
import { Title, Meta } from "@angular/platform-browser";
import { Injectable } from "@angular/core";

@Injectable()
export class SeoService extends BaseService
{
    /**
     *
     */
    constructor(private titleService:Title,
                private metaService:Meta) {
        super();
    }
    
    setGeneralSeo(title:string, description:string)
    {
        this.setTitle(title);
        this.setDescription(description); 
        this.setMetaOGUrl();
        this.setMetaOGImage();
        this.setTwitter(title, description);
    }
    
    setTitle(title:string)
    {
        this.titleService.setTitle(title);
        this.metaService.updateTag({name: "og:title", content: title});
    }
 
    setDescription(description:string)
    {
        this.metaService.updateTag({name: "description", content: description});
        this.metaService.updateTag({name: "og:description", content: description});
    }

    setMetaOGUrl()
    {
        this.metaService.updateTag({name: "og:url", content: document.location.href });
    }

    setMetaOGImage()
    {
        this.metaService.updateTag({name: "og:image:width", content: "1199" });
        this.metaService.updateTag({name: "og:image:height", content: "221" });
        this.metaService.updateTag({name: "og:image", content: this.siteUrl + "img/facebook.jpg" });
    }

    setTwitter(title:string, description:string)
    {
        this.metaService.updateTag({name: "twitter:card", content: "summary"});
        this.metaService.updateTag({name: "twitter:title", content: title});
        this.metaService.updateTag({name: "twitter:image", content: this.siteUrl + "img/facebook.jpg"});
        this.metaService.updateTag({name: "twitter:description", content: description});
    }



}