import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';

@Injectable()
export class UserTestService {
    url = configurl.apiServer.url + '/api/userTests';

    constructor(private http: HttpClient) {}

    getUserTests() {
        return this.http
            .get(this.url + `/user`, {
                observe: 'response',
                withCredentials: true,
            })
            .toPromise();
    }
}
