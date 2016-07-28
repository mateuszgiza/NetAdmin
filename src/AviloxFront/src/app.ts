import {RouterConfiguration, Router} from 'aurelia-router';

export class App {
    configureRouter(config:RouterConfiguration, router:Router):void {
        config.title = 'Aurelia';
        config.map([
            {
                route: ['', 'welcome'],
                name: 'welcome',
                moduleId: './welcome',
                nav: true,
                title: 'Welcome'
            },
            {
                route: 'issues',
                name: 'issues',
                moduleId: './issues',
                nav: true,
                title: 'Issues'
            }
        ]);

        this.router = router;
    }
}