import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
})
export class AppComponent {
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

    public getUserNameFromLocalStorage(): Observable<any> {
        const value = localStorage.getItem('userName');

        return of("Welcome " + value);
    }

    public logOut = () => {
        localStorage.removeItem('jwt');
        localStorage.removeItem('userEmail');
        localStorage.removeItem('userName');

        this.router.navigateByUrl('/login');
    };
}
