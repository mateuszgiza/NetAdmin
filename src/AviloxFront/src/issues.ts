/**
 * Created by matgi on 22.07.2016.
 */

import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class Issues {
    heading = "Issues";
    issues = [];

    constructor(http) {
        http.configure(cfg => {
            cfg
                .useStandardConfiguration()
                .withBaseUrl('https://aviloxcore.azurewebsites.net/')
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
        return this.http.fetch('Home/AllIssues')
            .then(response => response.json())
            .then(res => this.issues = res.issues);
    }
}