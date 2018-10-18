import * as React from "react";
import axios from 'axios';
import { Endpoints } from '../Endpoints';
import { PersonForm } from "./PersonForm";
import { PersonTable } from "./PersonTable";
import { Person, PersonFormButtonType, PeopleInterface } from "./types";
import { RouteComponentProps } from "react-router";


interface MainState {
    showPersonForm: boolean;
    personFormPerson?: Person;
    personFormButtonType: PersonFormButtonType
}

export class PersonMain extends React.Component<undefined, Partial<MainState & PeopleInterface>> {
    constructor(){
        super();

        this.state = { people: ([] as Person[]), showPersonForm: false, personFormButtonType: 'add' };  
     
        this.deleteClick = this.deleteClick.bind(this);
        this.editClick = this.editClick.bind(this);
        this.formButtonClick = this.formButtonClick.bind(this);
        this.newPersonClick = this.newPersonClick.bind(this);
        this.personFormCancelClick = this.personFormCancelClick.bind(this);
    }
    
    async componentDidMount() {
        this.loadPeople();
    }

    async deleteClick(person: Person) {
        await axios.delete(`${Endpoints.Person}${person.Id}`);
        await this.loadPeople();
    }

    public editClick(person: Person) {
        this.setState({showPersonForm: true, personFormPerson: person, personFormButtonType: 'edit'});
    }

  
    public async formButtonClick(person: Person) {
        let func = this.state.personFormButtonType === 'edit' ? axios.put : axios.post;
        await func(Endpoints.Person, person);
        await this.loadPeople();
        this.setState({showPersonForm: false});
    } 

    public  async loadPeople(){
        let people = await axios.get(Endpoints.Person, { headers: { "Authorization": localStorage.getItem('token') } });
        this.setState({ people: people.data });   
    }

    public newPersonClick() {
        //this.setState({ showPersonForm: true, personFormPerson: null, personFormButtonType: 'add' });
    }

    public personFormCancelClick() {    
        this.setState({showPersonForm: false});
    }
  
    public render() {

        return (
            <div className='container'>
                <h1>Persons</h1>          
                <div className="form-group">
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
