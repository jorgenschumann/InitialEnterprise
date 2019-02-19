import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from './types';
import { provideForRootGuard } from '@angular/router/src/router_module';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html'
})

export class CurrencyComponent {
  public currencies: Currency[];

  constructor(http: HttpClient) {
    http.get<Currency[]>('http://localhost:63928/api/currency/').subscribe(result => {
      this.currencies = result;
    }, error => console.error(error));
  }

  public edit(currency: Currency) {
    alert('edit');
  }

  public open() {
    alert('open');
  }
}

