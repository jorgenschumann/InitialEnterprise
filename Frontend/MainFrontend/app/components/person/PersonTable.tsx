import * as React from 'react';
import { PersonRow } from './PersonRow';
import { EditDeleteButtonClicks, PeopleInterface} from './types';

const PersonTable = (props: PeopleInterface & EditDeleteButtonClicks) => {
    return (
        <table className='table table-hover table-striped table-bordered'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {props.people && props.people.map(person =>
                    <PersonRow person={person}
                        key={person.id}
                        deleteClick={props.deleteClick}
                        editClick={props.editClick} />)}
            </tbody>
        </table>
    );
};

export { PersonTable};