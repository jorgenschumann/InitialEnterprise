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
    id: string;
    name: string;
    isoCode: string;
    rates: CurrencyRate[] | undefined;
}

export function isCurrency(currency: Currency): currency is Currency {
    const arg = (currency as Currency);
    return arg.name !== undefined
        && arg.isoCode !== undefined;
}
