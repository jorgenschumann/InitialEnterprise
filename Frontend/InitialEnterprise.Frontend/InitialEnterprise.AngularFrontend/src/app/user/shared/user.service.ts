import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserDto } from '../../models/user.types';
import { BaseApiService } from 'src/app/services/base-api.service';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })

export class UserService extends BaseApiService {

  list(): Observable<UserDto[]> {
    const url = `${this.config.Endpoint}/useraccount/`;
    return this.http.get<UserDto[]>(url).pipe(
      tap(_ => console.log(`list users`)),
      catchError(this.handleError<UserDto[]>(`list`))
    );
  }

  get(id: any): Observable<UserDto> {
    const url = `${this.config.Endpoint}/useraccount/${id}`;
    return this.http.get<UserDto>(url).pipe(
      tap(_ => console.log(`get user id=${id}`)),
      catchError(this.handleError<UserDto>(`get id=${id}`))
    );
  }

  put(user: any): Observable<any> {
    const url =  `${this.config.Endpoint}/useraccount/${user.id}`;
    return this.http.put(url, user).pipe(
      tap(_ => console.log(`put user id=${user.id}`)),
      catchError(this.handleError<any>('put user'))
    );
  }

  post(user: UserDto): Observable<UserDto> {
    return this.http.post<UserDto>(`${this.config.Endpoint}/useraccount`, user, this.httpOptions).pipe(
      tap((c: UserDto) => console.log(`post UserDto w/ id=${user.id}`)),
      catchError(this.handleError<UserDto>('post'))
    );
  }

  delete(id): Observable<UserDto> {
    const url =  `${this.config.Endpoint}/UserDto/${id}`;
    return this.http.delete<UserDto>(url, this.httpOptions).pipe(
      tap(_ => console.log(`deleted UserDto id=${id}`)),
      catchError(this.handleError<UserDto>('delete'))
    );
  }
}

