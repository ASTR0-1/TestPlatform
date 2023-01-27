import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';

@Injectable()
export class TestService {
    url = configurl.apiServer.url + '/api/';
    userEmail = localStorage.getItem('userEmail');

    constructor(private http: HttpClient) {}

    getUserTests() {
        return this.http.get(
            this.url + 'tests' + `?userEmail=${this.userEmail}`,
            { observe: 'response', withCredentials: true }
        );
    }

    getTestResult(testId: number, answers: number[]) {
        let answerString: string = '';

        answers.forEach(function (value) {
            answerString += `&answers=${value}`;
        });

        return this.http.get(
            this.url +
                'tests/result' +
                `?testId=${testId}&userEmail=${this.userEmail}` +
                answerString,
            { observe: 'response', withCredentials: true }
        );
    }
}
