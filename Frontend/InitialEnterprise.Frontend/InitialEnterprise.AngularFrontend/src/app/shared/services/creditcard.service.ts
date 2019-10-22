import { CreditCard } from './../models/creditcard';
import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { catchError, tap } from 'rxjs/operators';
import { CreditCardType } from '../models/creditcard';
import { Observable } from 'rxjs';
import { CommandHandlerAnswer } from '../models/commandHandlerAnswer';
import { HttpResponse } from '@angular/common/http';
import { Person } from '../models/person.types';

@Injectable({
  providedIn: 'root'
})

export class CreditCardService extends BaseApiService {

  public RootEntityEndpointFragment: string; // person, company, customer

  list(personId: any): Observable<Array<any>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/creditcards/`;
    return this.http.get<CreditCard[]>(url).pipe(
      tap(_ => console.log(`list creditcards`))
    );
  }

  get(personId: string, id: string): Observable<CreditCard> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/creditcards/${id}`;
    return this.http.get<CreditCard>(url).pipe(
      tap(_ => console.log(`get CreditCard id=${id}`)));
  }

  getCreditCardTypes(): Observable<CreditCardType[]> {
    const url = `${this.config.Endpoint}/creditcard/creditcardtypes`;
    return this.http.get<CreditCardType[]>(url).pipe(
      tap(_ => console.log(`get CreditCardTypes`)));
  }

  put(creditCard: CreditCard): Observable<CommandHandlerAnswer<Person>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${creditCard.personId}/creditcards`;
    return this.http.put<CommandHandlerAnswer<Person>>(url, creditCard).pipe(
      tap(_ => console.log(`deleted CreditCard id=${creditCard.id}`)));
  }

  post(creditCard: CreditCard): Observable<CommandHandlerAnswer<Person>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${creditCard.personId}/creditcards`;
    return this.http.post<CommandHandlerAnswer<Person>>(url, creditCard, this.httpOptions).pipe(
      tap(_ => console.log(`deleted CreditCard id=${creditCard.id}`)));
  }

  delete(rootEntityId: any, creditCard: CreditCard): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${rootEntityId}/creditcards/${creditCard.id}`;
    return this.http.delete<CreditCard>(url).pipe(
      tap(_ => console.log(`deleted CreditCard id=${creditCard.id}`)));
  }
}
