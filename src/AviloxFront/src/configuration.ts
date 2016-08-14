/**
 * Created by matgi on 05.08.2016.
 */

import {HttpClient} from "aurelia-fetch-client";

export class Configuration {
    public static apiUrl: string = "https://aviloxcore.azurewebsites.net/";
    //public static apiUrl: string = "http://localhost:5000/";

    public static Configure(http: HttpClient) {
        http.configure(cfg => {
            cfg
                .useStandardConfiguration()
                .withBaseUrl(this.apiUrl)
                .withDefaults({
                    headers: {
                        'X-Requested-With': 'Fetch',
                        'Access-Control-Allow-Origin': '*'
                    }
                })
        });
    }
}