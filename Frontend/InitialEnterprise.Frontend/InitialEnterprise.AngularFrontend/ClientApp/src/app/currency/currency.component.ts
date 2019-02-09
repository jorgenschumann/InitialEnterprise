import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html'
})

export class CurrencyComponent {
  public currencies: Currency[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Currency[]>(apiUrl + '/currency/').subscribe(result => {
      this.currencies = result;
    }, error => console.error(error));
  }

  public edit(currency: Currency) {
    alert(JSON.stringify(currency));
  }

  public open() {
    alert('open');
  }
}

