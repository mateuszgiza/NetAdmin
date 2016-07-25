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
                route: 'users',
                name: 'users',
                moduleId: './users',
                nav: true,
                title: 'Github Users'
            },
            {
                route: 'issues',
                name: 'issues',
                moduleId: './issues',
                nav: true,
                title: 'Issues'
            },
            {
                route: 'child-router',
                name: 'child-router',
                moduleId: './child-router',
                nav: true,
                title: 'Child Router'
            }
        ]);

        this.router = router;
    }
}