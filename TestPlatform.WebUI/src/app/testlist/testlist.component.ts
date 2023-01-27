import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Test } from '../entities/test';

import { TestService } from '../services/test.service';

@Component({
    selector: 'test-list',
    templateUrl: './testlist.component.html',
    styleUrls: ['./testlist.component.css'],
    providers: [TestService],
})
export class TestListComponent implements OnInit {
    tests: Test[] = [];

    constructor(private testService: TestService, private router: Router) {}

    ngOnInit(): void {
        this.loadTests();
    }

    confirm(test: Test) {
        this.router.navigateByUrl('confirmation', {
            state: { test: test },
        });
    }

    private loadTests(): void {
        this.testService.getUserTests().subscribe((resp) => {
            this.tests = <Test[]>resp.body;
        });
    }
}
