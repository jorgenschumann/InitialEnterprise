import * as React from "react";
import {PersonInterface, EditDeleteButtonClicks} from './types';

const PersonRow = (props: PersonInterface & EditDeleteButtonClicks) => {

    return <tr>
        <td>{props.person.Id}</td>
        <td>{props.person.FirstName}</td>
        <td>{props.person.LastName}</td>          
        <td>
            <div className="row">
                <div className="col-md-3">
                    <button className='btn btn-warning'
                        onClick={() => props.editClick(props.person)}>
                        Edit
                    </button>
                </div>
                <div className="col-md-2">
                    <button className='btn btn-danger'
                        onClick={() => props.deleteClick(props.person)}>
                        Delete
                </button>
                </div>
            </div>
        </td>
    </tr>
}

export { PersonRow};