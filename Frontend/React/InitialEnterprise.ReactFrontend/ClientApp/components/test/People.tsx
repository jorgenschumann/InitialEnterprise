import * as React from "react";
import { PersonEntity } from './PersonEntity';
import {PeopleInterface, EditDeleteButtonClicks} from './types';
import { Person } from "./Person";


const People = (props: PeopleInterface & EditDeleteButtonClicks) => {
    return (
        <table className="table table-hover table-striped table-bordered">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Age</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {props.people && props.people.map(person => 
                    <Person person={person} 
                            key={person.id} 
                            deleteClick={props.deleteClick} 
                            editClick={props.editClick}/> )}
            </tbody>
        </table>
    );
}

export {People};