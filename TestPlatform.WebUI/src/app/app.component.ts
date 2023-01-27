import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
})
export class AppComponent {
    userName = localStorage.getItem('userName');
    title = 'Test Platform';

    constructor(private jwtHelper: JwtHelperService, private router: Router) {}

    public isUserAuthenticated() {
        const token = localStorage.getItem('jwt');
        if (token && !this.jwtHelper.isTokenExpired(token)) {
            return true;
        } else {
            return false;
        }
    }

    public logOut = () => {
        localStorage.removeItem('jwt');
    };
}
