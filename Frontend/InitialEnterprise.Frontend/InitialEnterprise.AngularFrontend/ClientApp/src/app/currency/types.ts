interface Currency {
  id: string;
  name: string;
  isoCode: string;
  userId: string;
}

interface CurrencyRate {
  currencyRateDate: string;
  endOfDayRate: string;
  averageRate: string;
  toCurrencyCode: string;
  fromCurrencyCode: string;
}
