import { Injectable } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { BaseApiService } from './base-api.service';
import { Country } from '../models/country';
@Injectable({
  providedIn: 'root'
})

export class CountryService extends BaseApiService {
  list(): Observable<Country[]> {
    const url = `${this.config.Endpoint}/country/`;
    return this.http.get<Country[]>(url).pipe(
      tap(_ => console.log(`list countries`))
    );
  }
}
