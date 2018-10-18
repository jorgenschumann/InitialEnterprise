export type CurrencyFormButtonType = 'edit' | 'add' | undefined;

// tslint:disable-next-line:interface-name
export interface CurrenciesInterface {
    currencies: Currency[];
}

// tslint:disable-next-line:interface-name
export interface CurrencyInterface {
    currency: Currency;
}

// tslint:disable-next-line:interface-name
export interface EditDeleteButtonClicks {
    deleteClick: (currency: Currency) => void;
    editClick: (currency: Currency) => void;
}

// tslint:disable-next-line:interface-name
export interface CurrencyRate {
    currencyRateDate: string;
    endOfDayRate: string;
    averageRate: string;
    toCurrencyCode: string;
    fromCurrencyCode: string;
}

// tslint:disable-next-line:interface-name
export interface Currency {
    Id: string;
    Name: string;
    IsoCode: string;
    Rates: CurrencyRate[] | undefined;
}

export function isCurrency(currency: Currency): currency is Currency {
    const arg = (currency as Currency);
    return arg.Name !== undefined
        && arg.IsoCode !== undefined;
}
