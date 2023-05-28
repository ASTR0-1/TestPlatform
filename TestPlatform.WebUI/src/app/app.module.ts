import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuard } from 'src/guards/auth.guard';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';

import { LoginComponent } from './authentication/login/login.component';
import { RegistrationComponent } from './authentication/registration/registration.component';

import { TestListComponent } from './testlist/testlist.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { TestComponent } from './test/test.component';

const appRoutes: Routes = [
    {
        path: '',
        component: TestListComponent,
        canActivate: [AuthGuard],
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegistrationComponent },
    {
        path: 'confirmation',
        component: ConfirmationComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'test',
        component: TestComponent,
        canActivate: [AuthGuard],
    },
];

export function tokenGetter() {
    return localStorage.getItem('jwt');
}

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        RegistrationComponent,
        TestListComponent,
        TestComponent,
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes),
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                allowedDomains: ['localhost:7152'],
            },
        }),
        BrowserAnimationsModule,
        MatIconModule,
    ],
    providers: [AuthGuard],
    bootstrap: [AppComponent],
})
export class AppModule {}
