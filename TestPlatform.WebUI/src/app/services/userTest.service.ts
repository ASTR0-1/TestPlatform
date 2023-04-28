import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import configurl from 'src/assets/config.json';
import { UserTest } from '../entities/userTest';

@Injectable()
export class UserTestService {
    url = configurl.apiServer.url + '/api/userTests';

    constructor(private http: HttpClient) {}

    getUserTests(): Observable<UserTest[]> {
        return this.http
            .get<UserTest[]>(this.url + `/currentUser`, {
                observe: 'response',
                withCredentials: true,
            })
            .pipe(
                map((resp) => {
                    return resp.body || [];
                })
            );
    }
}
