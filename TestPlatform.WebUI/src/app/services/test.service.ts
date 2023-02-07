import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';

@Injectable()
export class TestService {
    url = configurl.apiServer.url + '/api/tests';

    constructor(private http: HttpClient) {}

    getTestResult(testId: number, answers: number[]) {
        let answerString: string = '';

        answers.forEach(function (value) {
            answerString += `&answers=${value}`;
        });

        return this.http.get(
            this.url + '/result' + `?testId=${testId}` + answerString,
            { observe: 'response', withCredentials: true }
        );
    }
}
