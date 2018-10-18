export type CurrencyFormButtonType = 'edit' | 'add' | undefined;

export interface CurrenciesInterface {
    currencies: Currency[];
}

export interface CurrencyInterface {
    currency: Currency;     
}

export interface EditDeleteButtonClicks {
    deleteClick: (currency: Currency) => void;
    editClick: (currency: Currency) => void;
}


export interface CurrencyRate {
    currencyRateDate: string;
    endOfDayRate: string;
    averageRate: string;
    toCurrencyCode: string;
    fromCurrencyCode: string;
}

export interface Currency {
    Id: string;
    Name: string;
    IsoCode: string;
    Rates: CurrencyRate[] | undefined;
}

export function isCurrency(currency: Currency): currency is Currency {
    let arg = (currency as Currency);
    return arg.Name !== undefined
        && arg.IsoCode !== undefined;
}
