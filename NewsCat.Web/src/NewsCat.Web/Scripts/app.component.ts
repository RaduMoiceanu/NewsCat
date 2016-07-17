import {Component} from 'angular2/core';

@Component({
    selector: 'news-cat-app',
    template: '<p>{​{Title}​}</p>'
})
export class AppComponent {
    Title: string;

    constructor() {
        this.Title = 'Hello World';
    }
}