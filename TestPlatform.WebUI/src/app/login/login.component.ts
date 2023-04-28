import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import configurl from 'src/assets/config.json';
import { JwtHelperService } from '@auth0/angular-jwt';

import { UserForLogin } from 'src/app/entities/userForLogin';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [AuthService],
})
export class LoginComponent {
    isInvalidLogin$!: Observable<boolean>;
    url = configurl.apiServer.url + '/api/account/';
    userForLogin: UserForLogin = new UserForLogin();

    constructor(
        private router: Router,
        private jwtHelper: JwtHelperService,
        private authService: AuthService
    ) {
        this.isInvalidLogin$ = this.authService.isInvalidLogin$;
    }

    public login = (form: NgForm) => {
        this.authService.signIn(this.userForLogin);
    };

    isUserAuthenticated() {
        const token = localStorage.getItem('jwt');
        if (token && !this.jwtHelper.isTokenExpired(token)) {
            return true;
        } else {
            return false;
        }
    }
}
