﻿import * as React from 'react';
import { CurrencyRow } from './CurrencyRow';
import { CurrenciesInterface, EditDeleteButtonClicks } from './types';

const CurrencyTable = (props: CurrenciesInterface & EditDeleteButtonClicks) => {
    return (
        <table className='table table-hover table-striped table-bordered'>
            <thead>
                <tr>
                    <th data-role='actions'>Actions</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
            </thead>
            <tbody>
                {props.currencies && props.currencies.map(currency =>
                    <CurrencyRow currency={currency}
                        key={currency.Id}
                        deleteClick={props.deleteClick}
                        editClick={props.editClick} />)}
            </tbody>
        </table>
    );
};


export { CurrencyTable };
