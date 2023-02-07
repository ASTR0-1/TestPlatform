import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';
import { UserForLogin } from '../entities/userForLogin';

@Injectable()
export class AuthService {
    url = configurl.apiServer.url + '/api/account';

    constructor(private http: HttpClient) {}

    signIn(userForLogin: UserForLogin) {
        return this.http.post(this.url + '/signIn', userForLogin, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            }),
            withCredentials: true,
        });
    }
}
