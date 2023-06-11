import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Question } from '../entities/question';
import { QuestionService } from '../services/question.service';
import { TestService } from '../services/test.service';
import { Observable, catchError, of } from 'rxjs';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
    providers: [QuestionService, TestService],
})
export class TestComponent implements OnInit {
    testId: number = 0;
    result: number | null = null;

    answers: number[] = [];

    questions$!: Observable<Question[]>;

    questionCount: number = 0;
    currentQuestionNumber: number = 0;

    form = new FormGroup({ option: new FormControl('', Validators.required) });

    constructor(
        private questionService: QuestionService,
        private testService: TestService,
        private router: Router
    ) {}

    ngOnInit(): void {
        if (history.state.testId === undefined) {
            this.router.navigateByUrl('');
        } else {
            this.testId = history.state.testId;
            this.questionCount = history.state.questionCount - 1;

            this.loadQuestions();
        }
    }

    submit() {
        this.answers.push(Number(this.form.value.option));

        this.form.reset();

        if (this.currentQuestionNumber < this.questionCount) {
            this.currentQuestionNumber++;
        } else {
            this.getResult();
        }
    }

    back() {
        this.router.navigateByUrl('');
    }

    getResult() {
        this.testService.getTestResult(this.testId, this.answers).subscribe(
            (result: number) => {
                this.result = result;
            },
            (error: any) => {
                console.error(error);
            }
        );
    }

    private loadQuestions(): void {
        this.questions$ = this.questionService
            .getTestQuestions(this.testId)
            .pipe(
                catchError((error) => {
                    console.error(error);
                    return of([]);
                })
            );
    }
}
