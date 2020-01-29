import { Injectable } from '@angular/core';
import { Currency } from '../types';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { BaseApiService } from 'src/app/shared/services/base-api.service';
import { CommandHandlerAnswer } from 'src/app/shared/models/commandHandlerAnswer';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService extends BaseApiService {

  list(): Observable<Currency[]> {
    return this.http.get<Currency[]>(`${this.config.Endpoint}/currency`)
      .pipe(
        tap(c => console.log('fetched currencies'))
      );
  }

  get(id: any): Observable<HttpResponse<CommandHandlerAnswer<Currency>>> {
    const url = `${this.config.Endpoint}/currency/${id}`;
    return this.http.get<CommandHandlerAnswer<Currency>>(url, { observe: 'response' }).pipe(
      tap(_ => console.log(`get currency id=${id}`))
    );
  }

  post(currency): Observable<Currency> {
    return this.http.post<Currency>(`${this.config.Endpoint}/currency`, currency, this.httpOptions).pipe(
      tap((c: Currency) => console.log(`post currency w/ id=${currency.id}`))
    );
  }

  put(currency: Currency): Observable<HttpResponse<CommandHandlerAnswer<Currency>>> {
    const url = `${this.config.Endpoint}/currency/${currency.id}`;
    return this.http.put<HttpResponse<CommandHandlerAnswer<Currency>>>(url, currency);
  }

  delete(id): Observable<Currency> {
    const url = `${this.config.Endpoint}/currency/${id}`;
    return this.http.delete<Currency>(url, this.httpOptions).pipe(
      tap(_ => console.log(`deleted currency id=${id}`))
    );
  }
}
