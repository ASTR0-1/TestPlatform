import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import configurl from 'src/assets/config.json';
import { JwtHelperService } from '@auth0/angular-jwt';

import { UserForLogin } from 'src/app/entities/userForLogin';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [AuthService],
})
export class LoginComponent {
    invalidLogin?: boolean;
    url = configurl.apiServer.url + '/api/account/';
    userForLogin: UserForLogin = new UserForLogin();

    constructor(
        private router: Router,
        private jwtHelper: JwtHelperService,
        private authService: AuthService
    ) {}

    public login = (form: NgForm) => {
        this.authService.signIn(this.userForLogin).subscribe({
            next: (response) => {
                const token = (<any>response).token;
                const userEmail = (<any>response).user.email;
                const userName = (<any>response).user.firstName;
                const userRoles = (<any>response).roles;

                localStorage.setItem('jwt', token);
                localStorage.setItem('userEmail', userEmail);
                localStorage.setItem('userName', userName);
                localStorage.setItem('userRoles', userRoles);

                this.invalidLogin = false;
                this.router.navigate(['']);
            },
            error: (err) => {
                this.invalidLogin = true;
            },
        });

        console.log(localStorage);
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
