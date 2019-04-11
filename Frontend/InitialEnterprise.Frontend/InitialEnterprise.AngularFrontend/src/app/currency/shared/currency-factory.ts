import { Guid } from 'src/app/core/guid';
import { Currency } from './../types';
export class CurrencyFactory {
  static empty(): Currency {
    const currency = {} as Currency;
    currency.id = Guid.newGuid();
    currency.isoCode = '';
    currency.name = '';
    return currency;
  }
}

