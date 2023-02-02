import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import configurl from 'src/assets/config.json';
import { JwtHelperService } from '@auth0/angular-jwt';

import { UserForLogin } from 'src/app/entities/userForLogin';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
})
export class LoginComponent {
    invalidLogin?: boolean;
    url = configurl.apiServer.url + '/api/account/';
    userForLogin: UserForLogin = new UserForLogin();

    constructor(
        private router: Router,
        private http: HttpClient,
        private jwtHelper: JwtHelperService
    ) {}

    public login = (form: NgForm) => {
        this.http
            .post(this.url + 'signIn', this.userForLogin, {
                headers: new HttpHeaders({
                    'Content-Type': 'application/json',
                }),
                withCredentials: true,
            })
            .subscribe({
                next: (response) => {
                    const token = (<any>response).token;
                    const userEmail = (<any>response).user.email;
                    const userName = (<any>response).user.firstName;

                    localStorage.setItem('jwt', token);
                    localStorage.setItem('userEmail', userEmail);
                    localStorage.setItem('userName', userName);

                    this.invalidLogin = false;
                    this.router.navigate(['']);
                },
                error: (err) => {
                    this.invalidLogin = true;
                },
            });
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
