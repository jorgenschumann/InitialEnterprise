import * as React from "react";
import { CurrenciesInterface, EditDeleteButtonClicks } from './types';
import { CurrencyRow } from "./CurrencyRow";

const CurrencyTable = (props: CurrenciesInterface & EditDeleteButtonClicks) => {
    return (
        <table className="table table-hover table-striped table-bordered">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Actions</th>
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
}

export { CurrencyTable };