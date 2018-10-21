import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar, Modal } from 'react-bootstrap';
import {CurrencyInterface, EditDeleteButtonClicks} from './types';

const CurrencyRow = (props: CurrencyInterface & EditDeleteButtonClicks) => {

    return <tr>
        <td>           
            <ButtonToolbar>
                <ButtonGroup bsSize='xsmall'>
                    <button className='btn btn-default'
                        onClick={() => props.editClick(props.currency)}><i className='material-icons'>open_in_browser</i>
                    </button>
                    <button className='btn btn-default'
                        onClick={() => props.deleteClick(props.currency)}><i className='material-icons'>delete_sweep</i>
                    </button>
                </ButtonGroup>
            </ButtonToolbar>
        </td>
        <td>{props.currency.id}</td>
        <td>{props.currency.name}</td>
        <td>{props.currency.isoCode}</td> 
    </tr>;
};


export { CurrencyRow};
