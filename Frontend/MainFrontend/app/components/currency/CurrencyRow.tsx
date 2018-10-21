import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar, Dropdown, DropdownButton, Glyphicon, MenuItem, Modal } from 'react-bootstrap';
import {CurrencyInterface, EditDeleteButtonClicks} from './types';

const CurrencyRow = (props: CurrencyInterface & EditDeleteButtonClicks) => {
    
    return <tr>
        <td>
            <Dropdown bsSize="xsmall">
                <Dropdown.Toggle>
                    <Glyphicon glyph="align-justify" />              
                </Dropdown.Toggle>
                <Dropdown.Menu className="super-colors">

                    <MenuItem onClick={() => props.editClick(props.currency)}>
                        <i className='material-icons'>open_in_browser</i></MenuItem>

                    <MenuItem onClick={() => props.deleteClick(props.currency)}>
                        <i className='material-icons'>delete_sweep</i></MenuItem>      
                    
                </Dropdown.Menu>
            </Dropdown>  
        </td>      
        <td>{props.currency.name}</td>
        <td>{props.currency.isoCode}</td> 
    </tr>;
};


export { CurrencyRow};
