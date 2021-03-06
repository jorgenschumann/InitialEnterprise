import * as React from 'react';
import {  ButtonGroup, ButtonToolbar } from 'react-bootstrap';
import { EmailAddressFormState, EmailButtonClicks} from './types';

const EmailAddressRow = (props: EmailAddressFormState & EmailButtonClicks) => {

    return <tr>
          <td>
            <ButtonToolbar>
                <ButtonGroup bsSize='xsmall'>
                <button className='btn btn-default'
                    onClick={() => props.EditClick(props.emailAddress)}><i className='material-icons'>open_in_browser</i>
                </button>
                <button className='btn btn-default'
                        onClick={() => props.DeleteClick(props.emailAddress)}><i className='material-icons'>delete</i>
                </button>
                </ButtonGroup>
            </ButtonToolbar>
        </td>             
        <td>{props.emailAddress.MailAddress}</td>
    </tr>;
};

export { EmailAddressRow };
