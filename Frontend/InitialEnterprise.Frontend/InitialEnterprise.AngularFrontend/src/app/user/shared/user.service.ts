import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../../models/user.types';
import { BaseApiService } from 'src/app/services/base-api.service';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService extends BaseApiService {

list(id: any): Observable<UserDto[]> {
    const url = `${this.config.Endpoint}/useraccount/query`;
    return this.http.get<UserDto[]>(url).pipe(
      tap(_ => console.log(`get user id=${id}`)),
      catchError(this.handleError<UserDto[]>(`get id=${id}`))
    );
  }

  get(id: any): Observable<UserDto> {
    const url = `${this.config.Endpoint}/useraccount/${id}`;
    return this.http.get<UserDto>(url).pipe(
      tap(_ => console.log(`get user id=${id}`)),
      catchError(this.handleError<UserDto>(`get id=${id}`))
    );
  }

}

