
import {inject} from "aurelia-framework";
import {HttpClient, json} from "aurelia-fetch-client";
import {Router} from "aurelia-router";
import {Configuration} from './../configuration';
import {IIssue, Issue} from "./Models/Issue";

@inject(HttpClient, Router)
export class New {
    http: HttpClient;
    router: Router;

    heading = "Issues";
    model: IIssue = new Issue();

    constructor(http, router) {
        this.http = http;
        this.router = router;
        Configuration.Configure(this.http);      
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