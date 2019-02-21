import { Injectable } from '@angular/core';
import { Currency } from '../types';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { BaseApiService } from 'src/app/services/base-api.service';


const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class CurrencyService extends BaseApiService {

  list(): Observable<Currency[]> {
        return this.http.get<Currency[]>(`${this.config.Endpoint}/currency`)
      .pipe(
        tap(c => console.log('fetched currencies')),
        catchError(this.handleError('list', []))
      );
  }

  get(id: any): Observable<Currency> {
    const url = `${this.config.Endpoint}/currency/${id}`;
    return this.http.get<Currency>(url).pipe(
      tap(_ => console.log(`get currency id=${id}`)),
      catchError(this.handleError<Currency>(`get id=${id}`))
    );
  }

  post(currency): Observable<Currency> {
    return this.http.post<Currency>(`${this.config.Endpoint}/currency`, currency, httpOptions).pipe(
      tap((c: Currency) => console.log(`post currency w/ id=${currency.id}`)),
      catchError(this.handleError<Currency>('post'))
    );
  }

  put(id: any, currency: any): Observable<any> {
    const url =  `${this.config.Endpoint}/currency/${id}`;
    return this.http.put(url, currency, httpOptions).pipe(
      tap(_ => console.log(`put Currency id=${id}`)),
      catchError(this.handleError<any>('put currency'))
    );
  }

  delete(id): Observable<Currency> {
    const url =  `${this.config.Endpoint}/currency/${id}`;
    return this.http.delete<Currency>(url, httpOptions).pipe(
      tap(_ => console.log(`deleted currency id=${id}`)),
      catchError(this.handleError<Currency>('delete'))
    );
  }
}
