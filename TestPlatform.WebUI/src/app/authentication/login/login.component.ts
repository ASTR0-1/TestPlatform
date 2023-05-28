import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import configurl from 'src/assets/config.json';

import { UserForLogin } from 'src/app/entities/userForLogin';

import { AuthService } from 'src/app/services/auth.service';
import { BaseFormComponent } from 'src/app/base.form.component';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [AuthService],
})
export class LoginComponent extends BaseFormComponent implements OnInit {
    url = configurl.apiServer.url + '/api/account/';

    isInvalidLogin$!: Observable<boolean>;

    constructor(private router: Router, private authService: AuthService) {
        super();

        this.isInvalidLogin$ = this.authService.isInvalidLogin$;
    }

    ngOnInit() {
        this.form = new FormGroup(
            {
                email: new FormControl('', [
                    Validators.required,
                ]),
                password: new FormControl('', [
                    Validators.required,
                ]),
            },
        );
    }

    public login = (form: FormGroup) => {
        var userForLogin = new UserForLogin();

        userForLogin.email = this.form.get("email")?.value;
        userForLogin.password = this.form.get("password")?.value;

        this.authService.signIn(userForLogin).subscribe(() => {
            this.router.navigateByUrl('');
        });
    };
}
