import {Router} from 'aurelia-router'

export class App {
    router: Router;

    configureRouter(config, router) {

        config.title = 'Aurelia';
        config.map([
            {route: ['', 'home'], name: 'home', moduleId: 'home/index', nav: true, title: 'Home'},
            {route: 'issues', name: 'issues', moduleId: 'issues/index', nav: true, title: 'Issues'},
            {route: 'issues/:id', name: 'issueShow', moduleId: 'issues/show', nav: false, title: 'Show issue'},
            {route: 'issues/new', name: 'issuesNew', moduleId: 'issues/new', nav: true, title: 'New Issue'}
        ]);

        this.router = router;
    }
}
