import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserSignInResultDto } from '../models/user.types';
import { BaseApiService } from './base-api.service';
import { Configuration } from 'src/app/configuration';

@Injectable({ providedIn: 'root' })
export class AuthenticationService extends BaseApiService {
  private currentUserSubject: BehaviorSubject<UserSignInResultDto>;
  public currentUser: Observable<UserSignInResultDto>;

  constructor(protected http: HttpClient,
    configuration: Configuration) {
    super(http, configuration);
    this.currentUserSubject = new BehaviorSubject<UserSignInResultDto>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserSignInResultDto {
    return this.currentUserSubject.value;
  }

  login(email: string, password: string) {
    const url = `${this.config.Endpoint}/useraccount/signin`;
    return this.http.post<UserSignInResultDto>(url, { email, password })
      .pipe(map(user => {
        if (user) {
          localStorage.setItem(this.config.localStorageUserKey, JSON.stringify(user));
          localStorage.setItem(this.config.localStorageTokenKey, 'Bearer ' + user.token);
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }

  logout() {
    localStorage.removeItem(this.config.localStorageUserKey);
    this.currentUserSubject.next(null);
  }
}
