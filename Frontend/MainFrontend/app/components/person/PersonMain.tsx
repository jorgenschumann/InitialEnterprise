import axios from 'axios';
import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar, Modal } from 'react-bootstrap';
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

        this.delete = this.delete.bind(this);
        this.edit = this.edit.bind(this);
        this.transfer = this.transfer.bind(this);
        this.create = this.create.bind(this);
        this.cancel = this.cancel.bind(this);
    }

    public async componentDidMount() {
        this.load();
    }

    public async delete(person: Person) {
        await axios.delete(`${Endpoints.Person}${person.id}`);
        await this.load();
    }

    public edit(person: Person) {
        this.setState({showPersonForm: true, personFormPerson: person, personFormButtonType: 'edit'});
    }

    public async transfer(person: Person) {
        const func = this.state.personFormButtonType === 'edit' ? axios.put : axios.post;
        await func(Endpoints.Person, person);
        await this.load();
        this.setState({showPersonForm: false});
    }

    public async load() {
        const people = await axios.get(Endpoints.Person, { headers: { Authorization: localStorage.getItem('token') } });
        this.setState({ people: people.data });
    }

    public create() {
        const person = {} as Person;
        this.setState({ showPersonForm: true, personFormPerson: person, personFormButtonType: 'add' });
    }

    public cancel() {
        this.setState({showPersonForm: false});
    }

    public render() {

        return (
            <div className='container'>
                <h1>People</h1>
                <ButtonToolbar>
                    <ButtonGroup bsSize='small'>
                    <button className='btn btn-default' onClick={this.load}><i className='material-icons'>autorenew</i></button>
                    <button className='btn btn-default' onClick={this.create}><i className='material-icons'>person_add</i></button>
                    </ButtonGroup>
                </ButtonToolbar>
                <br />
                {this.state.showPersonForm && <PersonForm
                    person={this.state.personFormPerson}
                    buttonType={this.state.personFormButtonType}
                    buttonClick={this.transfer}
                    cancelClick={this.cancel} />}
                <PersonTable people={this.state.people}
                    deleteClick={this.delete}
                    editClick={this.edit} />
            </div>);
    }
}
