import { Component } from '@angular/core';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../user/shared/user.service';
import { UserDto } from '../models/user.types';


@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    currentUser: UserDto;
    userFromApi: UserDto;

    constructor(
        private userService: UserService,
        private authenticationService: AuthenticationService
    ) {
        this.currentUser = this.authenticationService.currentUserValue.user;
    }

    ngOnInit() {
        this.userService.get(this.currentUser.id).pipe(first()).subscribe(user => {
            this.userFromApi = user;
        });
    }
}
