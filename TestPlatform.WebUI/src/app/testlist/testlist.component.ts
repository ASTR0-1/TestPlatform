import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Test } from '../entities/test';
import { UserTest } from '../entities/userTest';

import { UserTestService } from '../services/userTest.service';

@Component({
    selector: 'test-list',
    templateUrl: './testlist.component.html',
    styleUrls: ['./testlist.component.css'],
    providers: [UserTestService],
})
export class TestListComponent implements OnInit {
    private unfilteredUserTests: UserTest[] = [];

    userTests: UserTest[] = [];
    completedUserTests: UserTest[] = [];

    constructor(
        private userTestService: UserTestService,
        private router: Router
    ) {}

    async ngOnInit(): Promise<void> {
        await this.loadUserTests();

        this.userTests = this.unfilteredUserTests.filter(
            (t) => t.isCompleted == false
        );

        this.completedUserTests = this.unfilteredUserTests.filter(
            (t) => t.isCompleted == true
        );
    }

    confirm(test?: Test) {
        this.router.navigateByUrl('confirmation', {
            state: { test: test },
        });
    }

    private async loadUserTests() {
        await this.userTestService.getUserTests().then((resp) => {
            this.unfilteredUserTests = <UserTest[]>resp?.body;
        });
    }
}
