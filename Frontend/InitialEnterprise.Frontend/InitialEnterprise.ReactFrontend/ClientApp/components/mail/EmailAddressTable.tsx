import * as React from 'react';
import { EmailAddresses,  EmailButtonClicks } from './types';
import { ValidationResult } from '../types';
import { EmailAddressRow } from './EmailAddressRow';

const EmailAddressTable = (props: EmailAddresses & EmailButtonClicks) => {
    return (
        <table className='table table-hover table-striped table-bordered'>
            <thead>
                <tr>
                    <th></th>                
                    <th>Mail</th>
                </tr>
            </thead>
            <tbody>
                {props.EmailAddresses && props.EmailAddresses.map(mail =>
                    <EmailAddressRow EmailAddress ={mail}
                        ValidationResult={{} as ValidationResult}
                        key={mail.Id}
                        DeleteClick={props.DeleteClick}
                        EditClick={props.EditClick} />)}
            </tbody>
        </table>
    );
};

export { EmailAddressTable};
