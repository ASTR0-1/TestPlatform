import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';
import { UserForLogin } from '../entities/userForLogin';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class AuthService {
    url = configurl.apiServer.url + '/api/account';

    private isInvalidLoginSubject = new BehaviorSubject<boolean>(false);

    isInvalidLogin$: Observable<boolean> =
        this.isInvalidLoginSubject.asObservable();

    constructor(private http: HttpClient) {}

    signIn(userForLogin: UserForLogin) {
        this.http
            .post(this.url + '/signIn', userForLogin, {
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
                    const userRoles = (<any>response).roles;

                    localStorage.setItem('jwt', token);
                    localStorage.setItem('userEmail', userEmail);
                    localStorage.setItem('userName', userName);
                    localStorage.setItem('userRoles', userRoles);

                    this.isInvalidLoginSubject.next(false);
                },
                error: (err) => {
                    this.isInvalidLoginSubject.next(true);
                },
            });
    }
}
