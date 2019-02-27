import { Component } from '@angular/core';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../user/shared/user.service';
import { UserDto } from '../models/user.types';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
  constructor() { }

  ngOnInit() {
  }
}
