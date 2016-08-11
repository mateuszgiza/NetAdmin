import {inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import {Configuration} from './../configuration';

@inject(HttpClient)
export class Index {
    http: HttpClient;

    heading = "Issues";
    issues = [];

    constructor(http) {
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
    }

    activate() {
        return this.http.fetch('Issues/all')
            .then(response => response.json())
            .then(res => this.issues = res.issues);
    }

    delete(id: number): void {
        this.http.fetch('Issues/delete', {
            method: 'post',
            body: json(id)
        });

        this.issues = this.issues.filter(function( obj ) {
            return obj.id !== id;
        })
    }
}