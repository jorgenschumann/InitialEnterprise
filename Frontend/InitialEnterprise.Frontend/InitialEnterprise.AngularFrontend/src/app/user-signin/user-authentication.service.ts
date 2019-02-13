import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserSignInResultDto, Login } from './sigin-types';


@Injectable({ providedIn: 'root' })
export class UserAuthenticationService {
  private apiUrl: string;
    private currentUserSubject: BehaviorSubject<UserSignInResultDto>;
    public currentUser: Observable<UserSignInResultDto>;

    constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
      this.apiUrl = apiUrl;
      this.currentUserSubject = new BehaviorSubject<UserSignInResultDto>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): UserSignInResultDto {
        return this.currentUserSubject.value;
    }

    login(login: Login): any {
            // tslint:disable-next-line:no-debugger
            debugger;
      this.httpClient.post<UserSignInResultDto>(this.apiUrl + '/useraccount/signin/' , login)
            .pipe(map(user => {
                  // tslint:disable-next-line:no-debugger
                  debugger;
                if (user && user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    localStorage.setItem('Authorization', `Bearer ${user.token}`);
                    this.currentUserSubject.next(user);
                }
                return user;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
