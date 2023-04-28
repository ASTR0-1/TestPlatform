import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import configurl from 'src/assets/config.json';
import { Question } from '../entities/question';

@Injectable()
export class QuestionService {
    url = configurl.apiServer.url + '/api/';

    constructor(private http: HttpClient) {}

    getTestQuestions(testId: number): Observable<Question[]> {
        return this.http
            .get<Question[]>(this.url + 'questions' + `?testId=${testId}`, {
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
