import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { tap, catchError, retry, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { BaseApiService } from './base-api.service';
import { Person } from '../models/person.types';
import { CommandHandlerAnswer } from '../models/commandHandlerAnswer';

@Injectable({
  providedIn: 'root'
})
export class PersonService extends BaseApiService {

  list(): Observable<Array<any>> {
    const url = `${this.config.Endpoint}/person/`;
    return this.http.get<Person[]>(url).pipe(
      tap(_ => console.log(`list users`)),
      catchError(this.handleError<Person[]>(`list`))
    );
  }

  get(id: any): Observable<any> {
    const url = `${this.config.Endpoint}/person/${id}`;
    return this.http.get<Person>(url).pipe(
      tap(_ => console.log(`get person id=${id}`)),
      catchError(this.handleError<Person>(`get person id=${id}`))
    );
  }

  put(person: any): Observable<any> {
    const url =  `${this.config.Endpoint}/person/${person.id}`;
    return this.http
      .put<HttpResponse<CommandHandlerAnswer<Person>>>(url, person);
  }

  post(person: Person): Observable<any> {
    const url = `${this.config.Endpoint}/person`;
    return this.http.post<Person>(url, person, this.httpOptions).pipe(
      tap((c: Person) => console.log(`post person w/ id=${person.id}`)),
      catchError(this.handleError<Person>('post'))
    );
  }

  delete(person: Person): Observable<any> {
    const url = `${this.config.Endpoint}/person/${person.id}`;
    return this.http.delete<Person>(url).pipe(
      tap(_ => console.log(`deleted person id=${person.id}`)),
      catchError(this.handleError<Person>('delete'))
    );
  }
}
