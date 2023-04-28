import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Test } from '../entities/test';
import { UserTest } from '../entities/userTest';

import { UserTestService } from '../services/userTest.service';
import { Observable, map, of } from 'rxjs';

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
        private router: Router
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

    confirm(test?: Test) {
        this.router.navigateByUrl('confirmation', {
            state: { test: test },
        });
    }

    private loadUserTests() {
        this.unfilteredUserTests$ = this.userTestService.getUserTests();
    }
}
