import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';

@Injectable()
export class TestService {
    url = configurl.apiServer.url + '/api/tests';

    constructor(private http: HttpClient) {}

    getTestResult(testId: number, answers: number[]) {
        const answerString = answers
            .map((answer, index) => {
                const prefix = index === 0 ? '?' : '&';
                return `${prefix}answers=${answer}`;
            })
            .join('');
        const endpoint = `${this.url}/${testId}/result${answerString}`;

        return this.http.get(endpoint, {
            observe: 'response',
            withCredentials: true,
        });
    }
}
