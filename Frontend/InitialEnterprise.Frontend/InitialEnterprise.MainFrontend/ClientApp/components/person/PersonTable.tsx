import * as React from 'react';
import { PersonRow } from './PersonRow';
import { EditDeleteButtonClicks, PeopleInterface, ValidationResult} from './types';

const PersonTable = (props: PeopleInterface & EditDeleteButtonClicks) => {
    return (
        <table className='table table-hover table-striped table-bordered'>
            <thead>
                <tr>
                    <th>Actions</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
            </thead>
            <tbody>
                {props.people && props.people.map(person =>
                    <PersonRow person={person}
                        validationResult={{} as ValidationResult}
                        key={person.Id}                        
                        deleteClick={props.deleteClick}
                        editClick={props.editClick} />)}
            </tbody>
        </table>
    );
};

export { PersonTable};
