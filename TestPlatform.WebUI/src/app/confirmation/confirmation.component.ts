import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Test } from '../entities/test';

@Component({
    selector: 'confirmation',
    templateUrl: './confirmation.component.html',
    styleUrls: ['./confirmation.component.css'],
})
export class ConfirmationComponent implements OnInit {
    test: Test | undefined;
    toggleBool: boolean = true;

    constructor(private router: Router) {}

    ngOnInit(): void {
        if (history.state.test === undefined) {
            this.router.navigateByUrl('');
        }

        this.test = history.state.test;
    }

    changeEvent() {
        this.toggleBool = !this.toggleBool;
    }

    proceed() {
        if (this.test?.id === -1) {
            this.router.navigateByUrl('');
        } else {
            this.router.navigateByUrl('test', {
                state: {
                    testId: this.test?.id,
                    questionCount: this.test?.questionCount,
                },
            });
        }
    }
}
