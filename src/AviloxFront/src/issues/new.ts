
import {inject} from "aurelia-framework";
import {HttpClient, json} from "aurelia-fetch-client";
import {Router} from "aurelia-router";
import {Configuration} from './../configuration';
import {IssueType} from "./enums";
import {IEnumTypes, EnumExt} from "../helpers/enum-ext";

interface Model {
    title: string;
    text: string;
    issueType: IssueType;
    issueTypes: IEnumTypes[];
}

@inject(HttpClient, Router)
export class New {
    http: HttpClient;
    router: Router;

    heading = "Issues";
    model = <Model>{};

    constructor(http, router) {
        http.configure(cfg => {
            cfg
                .useStandardConfiguration()
                .withBaseUrl(Configuration.apiUrl)
                .withDefaults({
                    headers: {
                        'X-Requested-With': 'Fetch',
                        'Access-Control-Allow-Origin': '*'
                    }
                })
        });

        this.http = http;
        this.router = router;
        this.model.issueTypes = <IEnumTypes[]> EnumExt.getNamesAndValues(IssueType);
    }

    activate() {
        return "";
    }

    send = () => {
        this.http.fetch("Issues/add", {
            method: "post",
            body: json(this.model)
        }).then(res => this.router.navigate("issues"));
    };
}