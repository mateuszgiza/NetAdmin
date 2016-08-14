
import { inject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Router } from 'aurelia-router';
import { Configuration } from "../configuration";
import { IIssue } from "./Models/Issue";

@inject(HttpClient, Router)
export class Show {
    http: HttpClient;
    router: Router;

    issueId: number;
    issue: IIssue;
    exist: boolean;

    constructor(httpClient, router) {
        this.http = httpClient;
        this.router = router;
        Configuration.Configure(this.http);
    }

    activate(params, routeConfig, $navigationInstruction) {
        this.issueId = params.id;
        
        return this.http.fetch('Issues/' + this.issueId)
            .then(response => response.json())
            .then(res => {
                this.exist = res.exist;
                this.issue = res.issue;
            });
    }
}