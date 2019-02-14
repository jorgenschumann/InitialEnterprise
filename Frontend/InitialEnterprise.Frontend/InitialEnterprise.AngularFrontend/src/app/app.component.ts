// import { Component } from '@angular/core';


// @Component({
//   selector: 'my-app',
//   templateUrl: './app.component.html'
// })
// export class AppComponent {
// }

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuthenticationService } from './user-signin/user-authentication.service';
import { UserSignInResultDto } from './user-signin/sigin-types';

@Component({ selector: 'my-app', templateUrl: 'app.component.html' })
export class AppComponent {
  currentUser: UserSignInResultDto;

    constructor(
        private router: Router,
        private authenticationService: UserAuthenticationService
    ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/signin']);
    }
}
