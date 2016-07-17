import {Component} from 'angular2/core';
import "rxjs/Rx";

@Component({
    selector: 'news-cat-app',
    template: '<p>{​{Title}​}</p>'
})
export class AppComponent {
    Title: string;

    constructor() {
        this.Title = 'Hello World 115';
    }
}