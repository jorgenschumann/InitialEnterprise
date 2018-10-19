import axios from 'axios';
import * as React from 'react';
import { Button, Modal } from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { People } from './People';
import { PersonEntity } from './PersonEntity';
import { PersonForm } from './PersonForm';
import { PeopleInterface, PersonFormButtonType } from './types';

// tslint:disable-next-line:interface-name
interface MainState {
    showPersonForm: boolean;
    personFormPerson?: PersonEntity;
    personFormButtonType: PersonFormButtonType;
}

export class Main extends React.Component<RouteComponentProps<{}>, Partial<MainState & PeopleInterface>> {
    constructor() {
        super();
        this.state = {
            people: ([] as PersonEntity[]),
            showPersonForm: false,
            personFormButtonType: 'add'
        };

        this.deleteClick = this.deleteClick.bind(this);
        this.editClick = this.editClick.bind(this);
        this.formButtonClick = this.formButtonClick.bind(this);
        this.newPersonClick = this.newPersonClick.bind(this);
        this.personFormCancelClick = this.personFormCancelClick.bind(this);
    }

    public async deleteClick(person: PersonEntity) {
        await axios.delete(`/people/${person.id}`);
        await this.loadPeople();
    }

    public async formButtonClick(person: PersonEntity) {
        const func = this.state.personFormButtonType === 'edit' ? axios.put : axios.post;
        await func('/people', person);
        await this.loadPeople();
        this.setState({showPersonForm: false});
    }

    public async componentDidMount() {
        this.loadPeople();
    }

    public componentWillMount() {
        alert('componentWillMount');
    }

     public componentWillUnmount() {
        alert('componentWillUnmount');
    }

    public async loadPeople() {
        const people = await axios.get(Endpoints.Person);
        this.setState({ people: people.data });
    }

    public newPersonClick() {
        const person = {} as PersonEntity;
        this.setState({ showPersonForm: true, personFormPerson: person, personFormButtonType: 'add'});
    }

    public editClick(person: PersonEntity) {
        this.setState({ showPersonForm: true, personFormPerson: person, personFormButtonType: 'edit' });
    }

   public personFormCancelClick() {
        this.setState({showPersonForm: false});
    }

    public render() {
        return (
            <div className='container'>
                <h1>Persons</h1>
                <div className='form-group'>
                    <button className='btn btn-primary' onClick={this.loadPeople}>Reload</button>
                    <button className='btn btn-primary' onClick={this.newPersonClick}>New Person</button>
                </div>
                <br />
                {this.state.showPersonForm && <PersonForm
                    person={this.state.personFormPerson}
                    buttonType={this.state.personFormButtonType}
                    buttonClick={this.formButtonClick}
                    cancelClick={this.personFormCancelClick} />}
                <People people={this.state.people}
                    deleteClick={this.deleteClick}
                    editClick={this.editClick} />
            </div>);
    }
}
