import axios from 'axios';
import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar, ReactTable } from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { PersonForm } from './PersonForm';
import { PersonTable } from './PersonTable';
import { PeopleInterface, Person, PersonFormButtonType, ValidationResult, Model } from './types';
import { AlertComponent } from '../AlertComponent';
import { Http } from '../Http';

interface MainState {
    showAlert: boolean;
    showPersonForm: boolean;
    personFormModel?: Person;
    personFormButtonType: PersonFormButtonType;
    alert: string;
    validationResult?: ValidationResult ;
}

export class PersonMain extends React.Component<RouteComponentProps<{}>, Partial<MainState & PeopleInterface>> {
    constructor() {
        super();

        const validationResult = {} as ValidationResult;
        validationResult.IsValid = true;
        

        this.state = {
           people: ([] as Person[]), showPersonForm: false, personFormButtonType: 'add', alert: '', validationResult: validationResult};

        this.delete = this.delete.bind(this);
        this.edit = this.edit.bind(this);
        this.save = this.save.bind(this);
        this.create = this.create.bind(this);
        this.cancel = this.cancel.bind(this);
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
                    person={this.state.personFormModel} 
                    validationResult={this.state.validationResult}
                    buttonType={this.state.personFormButtonType}
                    buttonClick={this.save}
                    cancelClick={this.cancel} />}

                <PersonTable people={this.state.people}
                    deleteClick={this.delete}
                    editClick={this.edit} />              
                {this.state.showAlert && <AlertComponent
                    message={this.state.alert} style={'success'} />}
            </div>);
    }

    public async componentDidMount() {
        this.load();
    }

    public async delete(person: Person) {
        await Http.delete(`${Endpoints.Person}${person.Id}`);
        await this.load();
    }

    public edit(person: Person) {           
        const validationResult = {} as ValidationResult;
        validationResult.IsValid = true;       
        this.setState({ showPersonForm: true, personFormModel: person, personFormButtonType: 'edit', validationResult: validationResult});
    }

    public async save(person: Person) {
        const func = this.state.personFormButtonType === 'edit' ? Http.put : Http.post;    
        await func(Endpoints.Person, person).then((response) => {   
            const model = response.data as Model<Person>;     
            this.setState({ showPersonForm: !model.ValidationResult.IsValid, personFormModel: person, validationResult: model.ValidationResult });
            this.load();
        });      
    }

    public async load() {
      await Http.get(Endpoints.Person).then((response) => {
            this.setState({ people: response.data });
        });            
    }

    public create() {
        const person = {} as Person;   
        this.setState({ showPersonForm: true, personFormModel: person, personFormButtonType: 'add' });
    }

    public cancel() {
        this.setState({showPersonForm: false});
    }

  
}
