import { Currency } from './../types';
import { Guid } from 'src/app/shared/utils/guid';
export class CurrencyFactory {
  static empty(): Currency {
    const currency = {} as Currency;
    currency.id = Guid.newGuid();
    currency.isoCode = '';
    currency.name = '';
    return currency;
  }
}

