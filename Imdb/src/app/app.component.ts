import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'contact-app',
    templateUrl: './app.component.html'
})

export class AppComponent {

    public searchKey: string = "";

    constructor(private router: Router) { }

    onSearch() {
        this.router.navigateByUrl('/movie/' + this.searchKey);
    }

    onTitleClick() {
        this.router.navigateByUrl('/movie');
    }

}