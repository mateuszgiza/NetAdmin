import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Configuration } from './../configuration';

@inject(HttpClient, Router)
export class Index {
    http: HttpClient;
    router: Router;

    heading = "Issues";
    issues = [];

    constructor(http, router) {
        this.http = http;
        this.router = router;
        Configuration.Configure(this.http);
    }

    activate() {
        return this.http.fetch('Issues')
            .then(response => response.json())
            .then(res => this.issues = res.issues);
    }

    delete(id: number): void {
        this.http.fetch('Issues/delete', {
            method: 'post',
            body: json(id)
        });

        this.issues = this.issues.filter(function (obj) {
            return obj.id !== id;
        })
    }

    show(id: number): void {
        this.router.navigate("issues/" + id);
    }
}