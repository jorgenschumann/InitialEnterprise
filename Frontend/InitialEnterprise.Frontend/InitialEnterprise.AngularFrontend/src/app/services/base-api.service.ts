import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Configuration } from './endpoints';


@Injectable({
  providedIn: 'root'
})
export abstract class BaseApiService {

  protected httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  protected config: Configuration;

  constructor(protected http: HttpClient,   private configuration: Configuration) {
    this.config = configuration;
  }

  protected handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
