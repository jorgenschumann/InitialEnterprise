import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html'
})
export class CurrencyComponent {
  public currencies: Currency[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Currency[]>(baseUrl + '/currency/').subscribe(result => {
      this.currencies = result;
    }, error => console.error(error));
  }
}

interface Currency {
  id: string;
  name: string;
  isoCode: string;
  rates: CurrencyRate[] | undefined;
}

interface CurrencyRate {
  currencyRateDate: string;
  endOfDayRate: string;
  averageRate: string;
  toCurrencyCode: string;
  fromCurrencyCode: string;
}
