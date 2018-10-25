import * as React from "react";
import axios from 'axios';
import { PersonEntity } from './PersonEntity';
import { People } from './People';
import { PersonForm } from './PersonForm';
import { PersonFormButtonType, PeopleInterface } from './types';
import { Endpoints } from "../Endpoints";
import { Button, Modal } from 'react-bootstrap';

interface MainState {
    showPersonForm: boolean;
    personFormPerson?: PersonEntity;
    personFormButtonType: PersonFormButtonType
}

export class Main extends React.Component<undefined, Partial<MainState & PeopleInterface>> {
    constructor(){
        super();
        this.state = {
            people: ([] as PersonEntity[]),
            showPersonForm: false,
            personFormButtonType: 'add'
        }
    

        this.deleteClick = this.deleteClick.bind(this);
        this.editClick = this.editClick.bind(this);
        this.formButtonClick = this.formButtonClick.bind(this);
        this.newPersonClick = this.newPersonClick.bind(this);
        this.personFormCancelClick = this.personFormCancelClick.bind(this);
    }

    async deleteClick(person: PersonEntity) {
        await axios.delete(`/people/${person.id}`);
        await this.loadPeople();
    }
    
 

  
    async formButtonClick(person: PersonEntity) {
        let func = this.state.personFormButtonType === 'edit' ? axios.put : axios.post;
        await func('/people', person);
        await this.loadPeople();
        this.setState({showPersonForm: false});
    }

    async componentDidMount() {
        this.loadPeople();
    }

    componentWillMount() {
        alert('componentWillMount')
    }
    
     componentWillUnmount() {       
        alert('componentWillUnmount')
    }

    async loadPeople(){
        let people = await axios.get(Endpoints.Person);
        this.setState({ people: people.data });   
    }

    public newPersonClick() {
        let person = {} as PersonEntity;
        this.setState({ showPersonForm: true, personFormPerson: person, personFormButtonType: 'add'});
    }

    public editClick(person: PersonEntity) {
        this.setState({ showPersonForm: true, personFormPerson: person, personFormButtonType: 'edit' })
    }   

   public personFormCancelClick() {
        this.setState({showPersonForm: false});
    }
    
    public render() {
        return (
            <div>
                <div className='container'>
                    <h1>People</h1>
                    <button className="btn btn-primary" onClick={() => this.newPersonClick()}>open</button>
                    <button className='btn btn-primary' onClick={this.newPersonClick}>New Person</button>
                    <br />
                    {this.state.showPersonForm && <PersonForm
                        person={this.state.personFormPerson}
                        buttonType={this.state.personFormButtonType!}
                        buttonClick={this.formButtonClick}
                        cancelClick={this.personFormCancelClick} />}
                    <People people={this.state.people!}
                        deleteClick={this.deleteClick}
                        editClick={this.editClick} />
                </div>

            
                <div>
                    <div className="static-modal">
                        <Modal show={this.state.showPersonForm} container={this} aria-labelledby="contained-modal-title">
                            <Modal.Header >
                                <Modal.Title id="contained-modal-title">
                                    Title
                            </Modal.Title>
                            </Modal.Header>
                            <Modal.Body>
                           Body
                            </Modal.Body>
                            <Modal.Footer>                                
                            </Modal.Footer>
                        </Modal>
                    </div>
                </div>              
            </div>
        );
    }
}