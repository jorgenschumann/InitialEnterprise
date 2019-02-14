import { CurrencyComponent } from './currency/currency.component';
import { Component } from '@angular/core';
import { AuthenticationGuard } from './../infrastructure/guards/authentication-guard';
import { UserSigninComponent } from './user-signin/user-signin.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';


const appRoutes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthenticationGuard]
    },
    {
        path: 'signin',
        component: UserSigninComponent
    },

    { path: '**', redirectTo: '' }
];

export const Routing = RouterModule.forRoot(appRoutes);
