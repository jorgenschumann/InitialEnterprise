import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar } from 'react-bootstrap';
import {EditDeleteButtonClicks, PersonInterface} from './types';

const PersonRow = (props: PersonInterface & EditDeleteButtonClicks) => {

    return <tr>
          <td>
            <ButtonToolbar>
                <ButtonGroup bsSize='xsmall'>
                <button className='btn btn-default'
                    onClick={() => props.editClick(props.person)}><i className='material-icons'>open_in_browser</i>
                </button>
                <button className='btn btn-default'
                    onClick={() => props.deleteClick(props.person)}><i className='material-icons'>delete</i>
                </button>
                </ButtonGroup>
            </ButtonToolbar>
        </td>
        <td>{props.person.FirstName}</td>
        <td>{props.person.LastName}</td>
    </tr>;
};

export { PersonRow};
