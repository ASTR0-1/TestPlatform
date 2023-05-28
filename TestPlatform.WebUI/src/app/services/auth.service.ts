import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import configurl from 'src/assets/config.json';

import { UserForRegistration } from '../entities/userForRegistration';
import { UserForLogin } from '../entities/userForLogin';

@Injectable()
export class AuthService {
    url = configurl.apiServer.url + '/api/account';

    private isInvalidLoginSubject = new BehaviorSubject<boolean>(false);
    private isInvalidRegistrationSubject = new BehaviorSubject<boolean>(false);

    isInvalidLogin$: Observable<boolean> =
        this.isInvalidLoginSubject.asObservable();

    isInvalidRegistration$: Observable<boolean> =
        this.isInvalidRegistrationSubject.asObservable();

    constructor(private http: HttpClient) {}

    public signIn(userForLogin: UserForLogin): Observable<any> {
        return this.http
            .post(this.url + '/signIn', userForLogin, {
                headers: new HttpHeaders({
                    'Content-Type': 'application/json',
                }),
                withCredentials: true,
            })
            .pipe(
                tap(
                    (response) => {
                        this.processSucceedAuth(response);

                        this.isInvalidLoginSubject.next(false);
                    },
                    (err) => {
                        console.error(err);

                        this.isInvalidLoginSubject.next(true);
                    }
                )
            );
    }

    private processSucceedAuth(response: Object) {
        const token = (<any>response).token;
        const userEmail = (<any>response).user.email;
        const userName = (<any>response).user.firstName;

        this.saveCredsToLocalStorage(token, userEmail, userName);
    }

    public signUp(userForRegistration: UserForRegistration): Observable<any> {
        return this.http
            .post(this.url + '/signUp', userForRegistration, {
                headers: new HttpHeaders({
                    'Content-Type': 'application/json',
                }),
                withCredentials: true,
            })
            .pipe(
                tap(
                    (response) => {
                        this.processSucceedAuth(response);

                        this.isInvalidRegistrationSubject.next(false);
                    },
                    (err) => {
                        console.error(err);

                        this.isInvalidRegistrationSubject.next(true);
                    }
                )
            );
    }

    private saveCredsToLocalStorage(
        token: string,
        userEmail: string,
        userName: string
    ) {
        localStorage.setItem('jwt', token);
        localStorage.setItem('userEmail', userEmail);
        localStorage.setItem('userName', userName);
    }
}
