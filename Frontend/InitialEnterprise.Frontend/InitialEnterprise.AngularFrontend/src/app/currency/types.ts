
export interface Currency {
  id: string;
  name: string;
  isoCode: string;
  userId: string;
}

export interface CurrencyRate {
  currencyRateDate: string;
  endOfDayRate: string;
  averageRate: string;
  toCurrencyCode: string;
  fromCurrencyCode: string;
}
