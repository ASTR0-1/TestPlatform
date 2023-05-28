import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
    AbstractControl,
    AsyncValidatorFn,
    FormControl,
    FormGroup,
    ValidationErrors,
    Validators,
} from '@angular/forms';
import { Observable, of } from 'rxjs';
import configurl from 'src/assets/config.json';

import { UserForRegistration } from 'src/app/entities/userForRegistration';

import { AuthService } from 'src/app/services/auth.service';
import { BaseFormComponent } from 'src/app/base.form.component';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css'],
    providers: [AuthService],
})
export class RegistrationComponent extends BaseFormComponent implements OnInit {
    url = configurl.apiServer.url + '/api/account/';

    isInvalidRegistration$!: Observable<boolean>;

    constructor(private router: Router, private authService: AuthService) {
        super();

        this.isInvalidRegistration$ = this.authService.isInvalidRegistration$;
    }

    ngOnInit() {
        this.form = new FormGroup(
            {
                firstName: new FormControl('', [Validators.required]),
                lastName: new FormControl('', [Validators.required]),
                email: new FormControl('', [
                    Validators.required,
                    Validators.email,
                ]),
                isAdmin: new FormControl(false),
                password: new FormControl('', [
                    Validators.required,
                    Validators.minLength(6),
                    Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).+$/)
                ]),
                confirmPassword: new FormControl('', [
                    Validators.required,
                    Validators.minLength(6),
                ]),
            },
            null,
            this.passwordMatchValidator()
        );
    }

    public register = (form: FormGroup) => {
        var userForRegistration = new UserForRegistration();

        userForRegistration.firstName = this.form.get("firstName")?.value;
        userForRegistration.lastName = this.form.get("lastName")?.value;
        userForRegistration.email = this.form.get("email")?.value;
        userForRegistration.password = this.form.get("password")?.value;
        userForRegistration.confirmPassword = this.form.get("confirmPassword")?.value;
        userForRegistration.isAdmin = this.form.get("isAdmin")?.value;

        this.authService.signUp(userForRegistration).subscribe(() => {
            this.router.navigateByUrl('');
        });
    };

    passwordMatchValidator(): AsyncValidatorFn {
        return (
            control: AbstractControl
        ): Observable<ValidationErrors | null> => {
            const passwordControl = this.form?.get('password');
            const confirmPasswordControl =
                this.form?.get('confirmPassword');
            if (
                passwordControl &&
                confirmPasswordControl &&
                passwordControl.value !== confirmPasswordControl.value
            ) {
                confirmPasswordControl.setErrors({ passwordMismatch: true });
                return of({ passwordMismatch: true });
            } else {
                confirmPasswordControl?.setErrors(null);
                return of(null);
            }
        };
    }
}
