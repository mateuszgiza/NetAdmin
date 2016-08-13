define('app',["require", "exports"], function (require, exports) {
    "use strict";
    var App = (function () {
        function App() {
        }
        App.prototype.configureRouter = function (config, router) {
            config.title = 'Aurelia';
            config.map([
                { route: ['', 'home'], name: 'home', moduleId: 'home/index', nav: true, title: 'Home' },
                { route: 'issues', name: 'issues', moduleId: 'issues/index', nav: true, title: 'Issues' },
                { route: 'issues/new', name: 'issuesNew', moduleId: 'issues/new', nav: true, title: 'New Issue' }
            ]);
            this.router = router;
        };
        return App;
    }());
    exports.App = App;
});

define('configuration',["require", "exports"], function (require, exports) {
    "use strict";
    var Configuration = (function () {
        function Configuration() {
        }
        Configuration.apiUrl = "https://aviloxcore.azurewebsites.net/";
        return Configuration;
    }());
    exports.Configuration = Configuration;
});

define('environment',["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    exports.default = {
        debug: true,
        testing: true
    };
});

define('main',["require", "exports", './environment'], function (require, exports, environment_1) {
    "use strict";
    Promise.config({
        warnings: {
            wForgottenReturn: false
        }
    });
    function configure(aurelia) {
        aurelia.use
            .standardConfiguration()
            .feature('resources');
        if (environment_1.default.debug) {
            aurelia.use.developmentLogging();
        }
        if (environment_1.default.testing) {
            aurelia.use.plugin('aurelia-testing');
        }
        aurelia.start().then(function () { return aurelia.setRoot(); });
    }
    exports.configure = configure;
});

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define('navbar',["require", "exports", 'aurelia-framework'], function (require, exports, aurelia_framework_1) {
    "use strict";
    var Navbar = (function () {
        function Navbar() {
        }
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], Navbar.prototype, "router", void 0);
        return Navbar;
    }());
    exports.Navbar = Navbar;
});

define('issues/enums',["require", "exports"], function (require, exports) {
    "use strict";
    (function (IssueType) {
        IssueType[IssueType["Unknown"] = 0] = "Unknown";
        IssueType[IssueType["Bug"] = 10] = "Bug";
        IssueType[IssueType["Feature"] = 20] = "Feature";
        IssueType[IssueType["Proposal"] = 30] = "Proposal";
    })(exports.IssueType || (exports.IssueType = {}));
    var IssueType = exports.IssueType;
});

define('helpers/enum-ext',["require", "exports", "../issues/enums"], function (require, exports, enums_1) {
    "use strict";
    var EnumExt = (function () {
        function EnumExt() {
        }
        EnumExt.getNamesAndValues = function (e) {
            return this.getNames(e).map(function (n) { return { name: n, value: e[n] }; });
        };
        EnumExt.getNames = function (e) {
            return this.getObjValues(e).filter(function (v) { return typeof v === "string"; });
        };
        EnumExt.getValues = function (e) {
            return this.getObjValues(e).filter(function (v) { return typeof v === "number"; });
        };
        EnumExt.getObjValues = function (e) {
            return Object.keys(e).map(function (k) { return e[k]; });
        };
        EnumExt.getName = function (val) {
            var maps = this.getNamesAndValues(enums_1.IssueType);
            var elPos = maps.map(function (x) { return x.value; }).indexOf(val);
            return maps[elPos].name;
        };
        return EnumExt;
    }());
    exports.EnumExt = EnumExt;
});

define('helpers/converters',["require", "exports", "./enum-ext"], function (require, exports, enum_ext_1) {
    "use strict";
    var IssueTypeFormatValueConverter = (function () {
        function IssueTypeFormatValueConverter() {
        }
        IssueTypeFormatValueConverter.prototype.toView = function (value) {
            return enum_ext_1.EnumExt.getName(value);
        };
        return IssueTypeFormatValueConverter;
    }());
    exports.IssueTypeFormatValueConverter = IssueTypeFormatValueConverter;
    var TimeElapsedSinceNowValueConverter = (function () {
        function TimeElapsedSinceNowValueConverter() {
        }
        TimeElapsedSinceNowValueConverter.prototype.toView = function (value) {
            var lValue = new Date(value);
            var now = new Date().getTime();
            var diff = Math.round((now - lValue.getTime()) / 1000);
            var time;
            var unit;
            if (diff < 60) {
                time = diff;
                unit = "seconds";
            }
            else if (diff < 3600) {
                time = Math.round(diff / 60);
                unit = "minutes";
            }
            else if (diff < 3600 * 24) {
                time = Math.round(diff / 3600);
                unit = "hours";
            }
            else {
                time = Math.round(diff / (3600 * 24));
                unit = "days";
            }
            return time + " " + unit + " ago";
        };
        return TimeElapsedSinceNowValueConverter;
    }());
    exports.TimeElapsedSinceNowValueConverter = TimeElapsedSinceNowValueConverter;
});

define('home/index',["require", "exports"], function (require, exports) {
    "use strict";
    var Index = (function () {
        function Index() {
            this.message = 'Hello World!';
        }
        return Index;
    }());
    exports.Index = Index;
});

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define('issues/index',["require", "exports", 'aurelia-framework', 'aurelia-fetch-client', './../configuration'], function (require, exports, aurelia_framework_1, aurelia_fetch_client_1, configuration_1) {
    "use strict";
    var Index = (function () {
        function Index(http) {
            this.heading = "Issues";
            this.issues = [];
            http.configure(function (cfg) {
                cfg
                    .useStandardConfiguration()
                    .withBaseUrl(configuration_1.Configuration.apiUrl)
                    .withDefaults({
                    headers: {
                        'X-Requested-With': 'Fetch',
                        'Access-Control-Allow-Origin': '*'
                    }
                });
            });
            this.http = http;
        }
        Index.prototype.activate = function () {
            var _this = this;
            return this.http.fetch('Issues/all')
                .then(function (response) { return response.json(); })
                .then(function (res) { return _this.issues = res.issues; });
        };
        Index.prototype.delete = function (id) {
            this.http.fetch('Issues/delete', {
                method: 'post',
                body: aurelia_fetch_client_1.json(id)
            });
            this.issues = this.issues.filter(function (obj) {
                return obj.id !== id;
            });
        };
        Index = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient), 
            __metadata('design:paramtypes', [Object])
        ], Index);
        return Index;
    }());
    exports.Index = Index;
});

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define('issues/new',["require", "exports", "aurelia-framework", "aurelia-fetch-client", "aurelia-router", './../configuration', "./enums", "../helpers/enum-ext"], function (require, exports, aurelia_framework_1, aurelia_fetch_client_1, aurelia_router_1, configuration_1, enums_1, enum_ext_1) {
    "use strict";
    var New = (function () {
        function New(http, router) {
            var _this = this;
            this.heading = "Issues";
            this.model = {};
            this.send = function () {
                _this.http.fetch("Issues/add", {
                    method: "post",
                    body: aurelia_fetch_client_1.json(_this.model)
                }).then(function (res) { return _this.router.navigate("issues"); });
            };
            http.configure(function (cfg) {
                cfg
                    .useStandardConfiguration()
                    .withBaseUrl(configuration_1.Configuration.apiUrl)
                    .withDefaults({
                    headers: {
                        'X-Requested-With': 'Fetch',
                        'Access-Control-Allow-Origin': '*'
                    }
                });
            });
            this.http = http;
            this.router = router;
            this.model.issueTypes = enum_ext_1.EnumExt.getNamesAndValues(enums_1.IssueType);
        }
        New.prototype.activate = function () {
            return "";
        };
        New = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient, aurelia_router_1.Router), 
            __metadata('design:paramtypes', [Object, Object])
        ], New);
        return New;
    }());
    exports.New = New;
});

define('resources/index',["require", "exports"], function (require, exports) {
    "use strict";
    function configure(config) {
    }
    exports.configure = configure;
});

define('text!app.html', ['module'], function(module) { module.exports = "<template>\r\n    <require from=\"./navbar\"></require>\r\n    <navbar router.bind=\"router\"></navbar>\r\n\r\n    <div class=\"container m-t-3\">\r\n        <div class=\"site-bg\">\r\n            <router-view></router-view>\r\n        </div>\r\n    </div>\r\n\r\n</template>\r\n"; });
define('text!styles/main.css', ['module'], function(module) { module.exports = "h1,\r\nh2,\r\nh3,\r\nh4,\r\nh5,\r\np,\r\nfont,\r\n* {\r\n    font-family: 'Open Sans', sans-serif;\r\n}\r\n\r\nh1,\r\nh2,\r\nh3,\r\nh4,\r\nh5,\r\np,\r\nfont,\r\nlabel {\r\n    font-family: 'Open Sans', sans-serif;\r\n    color: lightgray;\r\n}\r\n\r\n.card-block > h4,\r\n.card-block > p {\r\n    color: #3c3f41;\r\n}\r\n\r\nbody {\r\n    background-color: darkslategrey;\r\n}\r\n\r\n.splash {\r\n    text-align: center;\r\n    margin: 10% 0 0 0;\r\n    box-sizing: border-box;\r\n}\r\n\r\n.splash .message {\r\n    font-size: 72px;\r\n    line-height: 72px;\r\n    text-shadow: rgba(0, 0, 0, 0.5) 0 0 15px;\r\n}\r\n\r\n.splash .fa-spinner {\r\n    text-align: center;\r\n    display: inline-block;\r\n    font-size: 72px;\r\n    margin-top: 50px;\r\n    text-shadow: rgba(0, 0, 0, 0.5) 0 0 15px;\r\n}\r\n\r\n.site-bg,\r\n.margin-top {\r\n    margin-top: 20px;\r\n}\r\n\r\n.site-bg,\r\n.pad-20 {\r\n    padding: 20px;\r\n}\r\n\r\n.site-bg,\r\n.round-corner-10 {\r\n    border-radius: 10px;\r\n}\r\n\r\n.site-bg,\r\n.dark-bg {\r\n    background-color: #373a3c;\r\n}\r\n\r\n.navbar {\r\n    box-shadow: rgba(0, 0, 0, 0.5) 0 0 15px;\r\n}\r\n\r\n.truncate {\r\n    width: inherit;\r\n    white-space: nowrap;\r\n    overflow: hidden;\r\n    text-overflow: ellipsis;\r\n}"; });
define('text!navbar.html', ['module'], function(module) { module.exports = "<template>\r\n    <nav class=\"navbar navbar-fixed-top navbar-dark bg-inverse\">\r\n        <div class=\"container\">\r\n\r\n            <div class=\"navbar-header\">\r\n                <a class=\"navbar-brand\" href=\"#\">\r\n                    <i class=\"fa fa-lg fa-fw\r\n                       ${router.isNavigating ? 'fa-spinner fa-spin' : 'fa-home'}\"></i>\r\n                    <span>${router.title}</span>\r\n                </a>\r\n            </div>\r\n\r\n            <ul class=\"nav navbar-nav\">\r\n                <li repeat.for=\"row of router.navigation\" class=\"nav-item ${row.isActive ? 'active' : ''}\">\r\n                    <a href.bind=\"row.href\" class=\"nav-link\">\r\n                        ${row.title}\r\n                        <i if.bind=\"row.settings.icon\" class=\"fa fa-${row.settings.icon}\"></i>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n\r\n        </div>\r\n    </nav>\r\n</template>\r\n\r\n<!--\r\n<template>\r\n    <nav class=\"navbar navbar-default navbar-fixed-top\" role=\"navigation\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#bs-example-navbar-collapse-1\">\r\n                <span class=\"sr-only\">Toggle Navigation</span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a class=\"navbar-brand\" href=\"#\">\r\n                <i class=\"fa fa-home\"></i>\r\n                <span>${router.title}</span>\r\n            </a>\r\n        </div>\r\n\r\n        <div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">\r\n            <ul class=\"nav navbar-nav\">\r\n                <li repeat.for=\"row of router.navigation\" class=\"${row.isActive ? 'active' : ''}\">\r\n                    <a data-toggle=\"collapse\" data-target=\"#bs-example-navbar-collapse-1.in\" href.bind=\"row.href\">${row.title}</a>\r\n                </li>\r\n            </ul>\r\n\r\n            <ul class=\"nav navbar-nav navbar-right\">\r\n                <li class=\"loader\" if.bind=\"router.isNavigating\">\r\n                    <i class=\"fa fa-spinner fa-spin fa-2x\"></i>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n</template>\r\n-->"; });
define('text!home/index.html', ['module'], function(module) { module.exports = "<template>\r\n    <h1>${message}</h1>\r\n    <button type=\"button\" class=\"btn btn-outline-success\">Success</button>\r\n</template>"; });
define('text!issues/index.html', ['module'], function(module) { module.exports = "<template>\r\n\r\n    <require from=\"./../helpers/converters\"></require>\r\n\r\n        <div class=\"container\">\r\n            <h2>${heading}</h2>\r\n        </div>\r\n\r\n        <div class=\"card-columns\">\r\n            <div class=\"card text-xs-center\" repeat.for=\"issue of issues\">\r\n\r\n                <div class=\"card-header\">\r\n                    ${issue.issueType | issueTypeFormat}\r\n                </div>\r\n\r\n                <div class=\"card-block\">\r\n                    <h4 class=\"card-title\">\r\n                        ${issue.title}\r\n                    </h4>\r\n                    <p class=\"card-text truncate\">\r\n                        ${issue.text}\r\n                    </p>\r\n                    <button class=\"btn btn-outline-danger btn-sm\" click.trigger=\"$parent.delete(issue.id)\">\r\n                        <i class=\"fa fa-trash fa-fw\"></i>Delete\r\n                    </button>\r\n                </div>\r\n\r\n                <div class=\"card-footer text-muted\">\r\n                    ${issue.creationDate | timeElapsedSinceNow}\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n</template>"; });
define('text!issues/new.html', ['module'], function(module) { module.exports = "<template>\r\n\r\n    <form role=\"form\" submit.delegate=\"send()\">\r\n        <h4>New Issue</h4>\r\n\r\n        <div class=\"form-group row\">\r\n            <label class=\"col-sm-2 col-form-label\">Title</label>\r\n            <div class=\"col-sm-10\">\r\n                <input class=\"form-control\" type=\"text\" value.bind=\"model.title\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            <label class=\"col-sm-2 col-form-label\">Text</label>\r\n            <div class=\"col-sm-10\">\r\n                <textarea class=\"form-control\" value.bind=\"model.text\"></textarea>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group row\">\r\n            <label class=\"col-sm-2 col-form-label\">Issue Type</label>\r\n            <div class=\"col-sm-10\">\r\n                <select value.bind=\"model.issueType\">\r\n                    <option model.bind=\"null\">Choose...</option>\r\n                    <option repeat.for=\"issueType of model.issueTypes\" model.bind=\"issueType.value\">\r\n                        ${issueType.name} (${issueType.value})\r\n                    </option>\r\n                </select>\r\n            </div>\r\n        </div>\r\n\r\n        <button type=\"submit\" class=\"btn btn-success\">Save</button>\r\n    </form>\r\n\r\n</template>"; });
//# sourceMappingURL=app-bundle.js.map