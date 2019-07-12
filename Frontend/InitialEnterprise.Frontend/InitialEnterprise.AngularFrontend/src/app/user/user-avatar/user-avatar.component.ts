import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UserDto } from 'src/app/shared/models/user.types';
import { UserService } from 'src/app/shared/services/user.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

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
        //this.currentUser = this.authenticationService.currentUserValue.user;
        //this.currentUser.image = this.currentUser.image = 'data:image/png;base64,' + this.currentUser.image;
      }
    }

    ngOnInit() {
        // this.userService.get(this.currentUser.id)
        // .pipe(first())
        // .subscribe(user => {
        //     this.userFromApi = user;
        // });
    }

}
