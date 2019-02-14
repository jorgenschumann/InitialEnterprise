import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserSignInResultDto, TokenDto, Login } from './sigin-types';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export class UserSigninService {
  private apiUrl: string;
  private httpClient: HttpClient;
  public userSignInResultDto: UserSignInResultDto;

  constructor(@Inject('API_URL') apiUrl: string, http: HttpClient) {
    this.apiUrl = apiUrl;
    this.httpClient = http;
  }

public login(login: Login): any {
    // return this.httpClient.post<UserSignInResultDto>(this.apiUrl + '/useraccount/signin/' , login);
    this.httpClient.post<UserSignInResultDto>(this.apiUrl + '/useraccount/signin/' , login)
      .subscribe(result => {
        if ( result.signInResult.succeeded === true) {
          localStorage.setItem('Authorization', `Bearer ${result.token}`);
        }
        alert(localStorage.getItem('Authorization'));
        return result;
    }, error => console.error(error));
  }
}
