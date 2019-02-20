import { Injectable } from '@angular/core';
import { Currency } from '../types';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = 'http://localhost:63928/api/currency/';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  constructor(private http: HttpClient) { }

  list(): Observable<Currency[]> {
    return this.http.get<Currency[]>(apiUrl)
      .pipe(
        tap(c => console.log('fetched currencies')),
        catchError(this.handleError('list', []))
      );
  }

  get(id: string): Observable<Currency> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Currency>(url).pipe(
      tap(_ => console.log(`get Currency id=${id}`)),
      catchError(this.handleError<Currency>(`get id=${id}`))
    );
  }

  post(currency): Observable<Currency> {
    return this.http.post<Currency>(apiUrl, currency, httpOptions).pipe(
      tap((c: Currency) => console.log(`post Currency w/ id=${currency.id}`)),
      catchError(this.handleError<Currency>('post'))
    );
  }

  put (id, currency): Observable<any> {
    const url = `${apiUrl}/${id}`;
    return this.http.put(url, currency, httpOptions).pipe(
      tap(_ => console.log(`put Currency id=${id}`)),
      catchError(this.handleError<any>('put currency'))
    );
  }

  delete (id): Observable<Currency> {
    const url = `${apiUrl}/${id}`;
    return this.http.delete<Currency>(url, httpOptions).pipe(
      tap(_ => console.log(`deleted currency id=${id}`)),
      catchError(this.handleError<Currency>('delete'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
