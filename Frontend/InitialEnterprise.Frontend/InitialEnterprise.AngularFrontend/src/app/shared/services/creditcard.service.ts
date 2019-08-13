import { CreditCard } from './../models/creditcard';
import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { catchError, tap } from 'rxjs/operators';
import { CreditCardType } from '../models/creditcard';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CreditCardService extends BaseApiService {

  public RootEntityEndpointFragment: string; // person, company, customer

  list(personId: any): Observable<Array<any>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/creditcards/`;
    return this.http.get<CreditCard[]>(url).pipe(
      tap(_ => console.log(`list creditcards`)),
      catchError(this.handleError<CreditCard[]>(`list`))
    );
  }

  get(personId: any, id: any): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/creditcards/${id}`;
    return this.http.get<CreditCard>(url).pipe(
      tap(_ => console.log(`get CreditCard id=${id}`)),
      catchError(this.handleError<CreditCard>(`get CreditCard for ${this.RootEntityEndpointFragment} with id=${id}`))
    );
  }

  getCreditCardTypes(): Observable<CreditCardType[]> {
    const url = `${this.config.Endpoint}/creditcard/creditcardtypes`;
    return this.http.get<CreditCardType[]>(url).pipe(
      tap(_ => console.log(`get CreditCardTypes`)),
      catchError(this.handleError<CreditCardType[]>(`get CreditCardTypes`))
    );
  }

  delete(rootEntityId: any, creditCard: CreditCard): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${rootEntityId}/creditcards/${creditCard.id}`;
    return this.http.delete<CreditCard>(url).pipe(
      tap(_ => console.log(`deleted CreditCard id=${creditCard.id}`)),
      catchError(this.handleError<CreditCard>('delete'))
    );
  }

}
