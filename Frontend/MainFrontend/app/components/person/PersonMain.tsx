import axios from 'axios';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { PersonForm } from './PersonForm';
import { PersonTable } from './PersonTable';
import { PeopleInterface, Person, PersonFormButtonType } from './types';


// tslint:disable-next-line:interface-name
interface MainState {
    showPersonForm: boolean;
    personFormPerson?: Person;
    personFormButtonType: PersonFormButtonType;
}

export class PersonMain extends React.Component<RouteComponentProps<{}>, Partial<MainState & PeopleInterface>> {
    constructor() {
        super();

        this.state = { people: ([] as Person[]), showPersonForm: false, personFormButtonType: 'add' };

        this.deleteClick = this.deleteClick.bind(this);
        this.editClick = this.editClick.bind(this);
        this.formButtonClick = this.formButtonClick.bind(this);
        this.newPersonClick = this.newPersonClick.bind(this);
        this.personFormCancelClick = this.personFormCancelClick.bind(this);
    }

    public async componentDidMount() {
        this.loadPeople();
    }

    public async deleteClick(person: Person) {
        await axios.delete(`${Endpoints.Person}${person.id}`);
        await this.loadPeople();
    }

    public editClick(person: Person) {
        this.setState({showPersonForm: true, personFormPerson: person, personFormButtonType: 'edit'});
    }

    public async formButtonClick(person: Person) {
        const func = this.state.personFormButtonType === 'edit' ? axios.put : axios.post;
        await func(Endpoints.Person, person);
        await this.loadPeople();
        this.setState({showPersonForm: false});
    }

    public  async loadPeople() {
        const people = await axios.get(Endpoints.Person, { headers: { Authorization: localStorage.getItem('token') } });
        this.setState({ people: people.data });
    }

    public newPersonClick() {
        // this.setState({ showPersonForm: true, personFormPerson: null, personFormButtonType: 'add' });
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
                <PersonTable people={this.state.people}
                    deleteClick={this.deleteClick}
                    editClick={this.editClick} />
            </div>);
    }
}
