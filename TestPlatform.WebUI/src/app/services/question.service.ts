import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import configurl from 'src/assets/config.json';

@Injectable()
export class QuestionService {
    url = configurl.apiServer.url + '/api/';

    constructor(private http: HttpClient) {}

    getTestQuestions(testId: number) {
        return this.http.get(this.url + 'questions' + `?testId=${testId}`, {
            observe: 'response',
            withCredentials: true,
        });
    }
}
