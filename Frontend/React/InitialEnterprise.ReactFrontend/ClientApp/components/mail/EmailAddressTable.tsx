import * as React from 'react';
import { EmailAddresses, EmailButtonClicks } from './types';
import { ValidationResult } from '../types';
import { EmailAddressRow } from './EmailAddressRow';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

const EmailAddressTable = (props: EmailAddresses & EmailButtonClicks) => {
    function onAfterInsertRow(row) {
        let newRowStr = '';

        for (const prop in row) {
            newRowStr += prop + ': ' + row[prop] + ' \n';
        }
        alert('The new row is:\n ' + newRowStr);
    }

    const options = {
        afterInsertRow: onAfterInsertRow
    };

    return (
        <BootstrapTable data={props.EmailAddresses!} selectRow={{ mode: 'checkbox', clickToSelect: true }} insertRow={true} deleteRow={true} options={options}>
            <TableHeaderColumn dataField='Id' isKey>Id</TableHeaderColumn>
            <TableHeaderColumn dataField='PersonId'>Person</TableHeaderColumn>
            <TableHeaderColumn dataField='MailAddress'>MailAddress</TableHeaderColumn>
        </BootstrapTable>
    );
}

//return (
//    <table className='table table-hover table-striped table-bordered'>
//        <thead>
//            <tr>
//                <th></th>
//                <th>Mail</th>
//            </tr>
//        </thead>
//        <tbody>
//            {props.EmailAddresses && props.EmailAddresses.map(mail =>
//                <EmailAddressRow emailAddress={mail}
//                    validationResult={{} as ValidationResult}
//                    key={mail.Id}
//                    DeleteClick={props.DeleteClick}
//                    EditClick={props.EditClick} />)}
//        </tbody>
//    </table>
//);

export { EmailAddressTable };