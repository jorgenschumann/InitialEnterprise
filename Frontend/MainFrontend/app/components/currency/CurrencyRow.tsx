import * as React from 'react';
import {CurrencyInterface, EditDeleteButtonClicks} from './types';

const CurrencyRow = (props: CurrencyInterface & EditDeleteButtonClicks) => {

    return <tr>
        <td>{props.currency.Id}</td>
        <td>{props.currency.Name}</td>
        <td>{props.currency.IsoCode}</td>
        <td>
            <div className='row'>
                <div className='col-md-3'>
                    <button className='btn btn-warning'
                        onClick={() => props.editClick(props.currency)}>
                        Edit
                    </button>
                </div>
                <div className='col-md-2'>
                    <button className='btn btn-danger'
                        onClick={() => props.deleteClick(props.currency)}>
                        Delete
                </button>
                </div>
            </div>
        </td>
    </tr>;
};


export { CurrencyRow};
