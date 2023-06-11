import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Test } from '../entities/test';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

@Component({
    selector: 'confirmation-dialog',
    templateUrl: './confirmation.component.html',
    styleUrls: ['./confirmation.component.css'],
    standalone: true,
    imports: [MatDialogModule, MatButtonModule],
})
export class ConfirmationComponent implements OnInit {
    toggleBool: boolean = true;

    constructor(
        private router: Router,
        public dialogRef: MatDialogRef<ConfirmationComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Test
    ) {}

    ngOnInit(): void {
        if (history.state.test === undefined) {
            this.router.navigateByUrl('');
        }
    }

    changeEvent() {
        this.toggleBool = !this.toggleBool;
    }

    proceed() {
        if (this.data?.id === -1) {
            this.router.navigateByUrl('');
        } else {
            this.router.navigateByUrl('test', {
                state: {
                    testId: this.data?.id,
                    questionCount: this.data?.questionCount,
                },
            });
        }

        this.dialogRef.close();
    }
}
