import { Component, OnInit } from '@angular/core';

import { Test } from '../entities/test';
import { UserTest } from '../entities/userTest';

import { UserTestService } from '../services/userTest.service';
import { Observable, map } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
    selector: 'test-list',
    templateUrl: './testlist.component.html',
    styleUrls: ['./testlist.component.css'],
    providers: [UserTestService],
})
export class TestListComponent implements OnInit {
    private unfilteredUserTests$!: Observable<UserTest[]>;

    userTests$!: Observable<UserTest[]>;
    completedUserTests$!: Observable<UserTest[]>;

    constructor(
        private userTestService: UserTestService,
        public dialog: MatDialog
    ) {}

    async ngOnInit(): Promise<void> {
        this.loadUserTests();

        this.userTests$ = this.unfilteredUserTests$.pipe(
            map((userTests: UserTest[]) =>
                userTests.filter((t) => t.isCompleted === false)
            )
        );

        this.completedUserTests$ = this.unfilteredUserTests$.pipe(
            map((userTests: UserTest[]) =>
                userTests.filter((t) => t.isCompleted === true)
            )
        );
    }

    confirmDialog(test?: Test) {
        this.dialog.open(ConfirmationComponent, {
            height: '250px',
            width: '500px',
            data: test,
        });
    }

    private loadUserTests() {
        this.unfilteredUserTests$ = this.userTestService.getUserTests();
    }
}
