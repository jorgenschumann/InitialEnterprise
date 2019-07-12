import { Injectable } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { BaseApiService } from './base-api.service';
import { Address } from '../models/address';
import { CommandHandlerAnswer } from '../models/commandHandlerAnswer';

@Injectable({
  providedIn: 'root'
})

export class AddressService extends BaseApiService {

  public RootEntityEndpointFragment: string; // person, company, customer

  list(personId: any): Observable<Array<any>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/addresses/`;
    return this.http.get<Address[]>(url).pipe(
      tap(_ => console.log(`list addresses`)),
      catchError(this.handleError<Address[]>(`list`))
    );
  }

  get(personId: any, id: any): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${personId}/addresses/${id}`;
    return this.http.get<Address>(url).pipe(
      tap(_ => console.log(`get Address id=${id}`)),
      catchError(this.handleError<Address>(`get addresses for ${this.RootEntityEndpointFragment} with id=${id}`))
    );
  }

  put(address: Address): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${address.personId}/addresses`;
    return this.http
      .put<HttpResponse<CommandHandlerAnswer<Address>>>(url, address);
  }

  post(address: Address): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${address.personId}/addresses`;
    return this.http.post<Address>(url, address, this.httpOptions).pipe(
      tap((c: Address) => console.log(`post mailaddress w/ id=${address.id}`)),
      catchError(this.handleError<Address>('post'))
    );
  }

  delete(rootEntityId: any, address: Address): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${rootEntityId}/addresses/${address.id}`;
    return this.http.delete<Address>(url).pipe(
      tap(_ => console.log(`deleted person id=${address.id}`)),
      catchError(this.handleError<Address>('delete'))
    );
  }
}
