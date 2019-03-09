import { Component, OnInit } from '@angular/core';
import { UserDto } from 'src/app/models/user.types';
import { UserService } from '../shared/user.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-user-avatar',
  templateUrl: './user-avatar.component.html',
  styleUrls: ['./user-avatar.component.css']
})
export class UserAvatarComponent implements OnInit {
  currentUser: UserDto;
  userFromApi: UserDto;

    constructor(
        private userService: UserService,
        private authenticationService: AuthenticationService
    ) {
      if (this.authenticationService.currentUserValue != null) {
        this.currentUser = this.authenticationService.currentUserValue.user;
      }
    }

    ngOnInit() {
        this.userService.get(this.currentUser.id)
        .pipe(first())
        .subscribe(user => {
            this.userFromApi = user;
        });
    }

}
