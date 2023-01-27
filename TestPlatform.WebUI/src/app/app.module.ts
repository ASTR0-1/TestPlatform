import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuard } from 'src/guards/auth.guard';

import { AppComponent } from './app.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { TestListComponent } from './testlist/testlist.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { TestComponent } from './test/test.component';

const appRoutes: Routes = [
    { path: '', component: HomepageComponent },
    { path: 'login', component: LoginComponent },
    {
        path: 'testlist',
        component: TestListComponent,
        canActivate: [AuthGuard],
    },
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
        HomepageComponent,
        LoginComponent,
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
    ],
    providers: [AuthGuard],
    bootstrap: [AppComponent],
})
export class AppModule {}
