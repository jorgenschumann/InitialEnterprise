import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { UserDto } from '../models/user.types';
import { BaseApiService } from './base-api.service';

@Injectable({ providedIn: 'root' })

export class UserService extends BaseApiService {

  list(): Observable<UserDto[]> {
    const url = `${this.config.Endpoint}/useraccount/`;
    return this.http.get<UserDto[]>(url).pipe(
      tap(_ => console.log(`list users`))
    );
  }

  get(id: any): Observable<UserDto> {
    const url = `${this.config.Endpoint}/useraccount/${id}`;
    return this.http.get<UserDto>(url).pipe(
      tap(_ => console.log(`get user id=${id}`)));
  }

  put(user: any): Observable<any> {
    const url = `${this.config.Endpoint}/useraccount/${user.id}`;
    return this.http.put(url, user).pipe(
      tap(_ => console.log(`put user id=${user.id}`))
    );
  }

  post(user: UserDto): Observable<UserDto> {
    return this.http.post<UserDto>(`${this.config.Endpoint}/useraccount`, user, this.httpOptions).pipe(
      tap((c: UserDto) => console.log(`post user w/ id=${user.id}`))
    );
  }

  delete(user: UserDto): Observable<UserDto> {
    const url = `${this.config.Endpoint}/useraccount/${user.id}`;
    return this.http.delete<UserDto>(url).pipe(
      tap(_ => console.log(`deleted user id=${user.id}`))
    );
  }
}

