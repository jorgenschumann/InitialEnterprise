import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserSignInResultDto, Role } from './shared/models/user.types';
import { AuthenticationService } from './shared/services/authentication.service';

// tslint:disable-next-line:component-selector
@Component({ selector: 'my-app', templateUrl: 'app.component.html' })
export class AppComponent {
    currentUser: UserSignInResultDto;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

    get isAdmin() {
        return this.currentUser && this.currentUser.user.role === Role.Admin;
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }

}
