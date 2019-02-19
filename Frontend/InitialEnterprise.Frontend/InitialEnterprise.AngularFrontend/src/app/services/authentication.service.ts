import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserSignInResultDto } from '../models/user.types';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<UserSignInResultDto>;
    public currentUser: Observable<UserSignInResultDto>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<UserSignInResultDto>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): UserSignInResultDto {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<UserSignInResultDto>('http://localhost:63928/api/useraccount/signin', { email, password })
            .pipe(map(user => {
                if (user && user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
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
