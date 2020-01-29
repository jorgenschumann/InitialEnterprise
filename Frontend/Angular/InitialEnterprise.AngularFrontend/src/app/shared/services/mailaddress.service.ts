import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { tap, catchError, retry, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MailAddress } from '../models/mailaddress';
import { BaseApiService } from './base-api.service';
import { CommandHandlerAnswer } from '../models/commandHandlerAnswer';
@Injectable({
  providedIn: 'root'
})
export class MailaddressService extends BaseApiService {

  public RootEntityEndpointFragment: string; // person, company, customer

  list(): Observable<Array<MailAddress>> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/emailaddresses/`;
    return this.http.get<MailAddress[]>(url).pipe(
      tap(_ => console.log(`list mailaddresses`))
    );
  }

  get(id: any): Observable<MailAddress> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/emailaddresses/${id}`;
    return this.http.get<MailAddress>(url).pipe(
      tap(_ => console.log(`get MailAddress id=${id}`))
    );
  }

  put(mailaddress: MailAddress): Observable<any> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${mailaddress.personId}/emailaddresses`;
    return this.http
      .put<HttpResponse<CommandHandlerAnswer<MailAddress>>>(url, mailaddress);
  }

  post(mailaddress: MailAddress): Observable<MailAddress> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${mailaddress.personId}/emailaddresses`;
    return this.http.post<MailAddress>(url, mailaddress, this.httpOptions).pipe(
      tap((c: MailAddress) => console.log(`post permailaddressson w/ id=${mailaddress.id}`))
    );
  }

  delete(rootEntityId: any, mailaddress: MailAddress): Observable<MailAddress> {
    const url = `${this.config.Endpoint}/${this.RootEntityEndpointFragment}/${rootEntityId}/emailaddresses/${mailaddress.id}`;
    return this.http.delete<MailAddress>(url).pipe(
      tap(_ => console.log(`deleted person id=${mailaddress.id}`))
    );
  }

}
