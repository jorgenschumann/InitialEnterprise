import * as React from 'react';
import { ControlLabel, Modal, Dropdown, HelpBlock, ButtonToolbar, DropdownButton, FormGroup, Glyphicon, MenuItem } from 'react-bootstrap';
import { Form, FormControl, Col, Button } from 'react-bootstrap';
import { Person as PersonEntity, EmailAddress, PersonFormButtonType, Person,  PersonFormState} from './types';
import { isValidElement } from 'react';
import { ValidationResult } from '../types';
import { EmailAddressTable } from '../mail/EmailAddressTable';

interface PersonFormProps {
    person?: PersonEntity;
    buttonClick: (person: PersonEntity) => void;
    buttonType: PersonFormButtonType;
    cancelClick: () => void;
    validationResult?: ValidationResult;
}

export class PersonForm extends React.Component<PersonFormProps, Partial<PersonFormState>> {
    constructor(props: PersonFormProps & ValidationResult) {
        super(props);
        this.state = { person: props.person ? { ...props.person } : { Id: '', Title: '', PersonType: '', FirstName: '', LastName: '', EmailAddresses: [] }, validationResult: props.validationResult };
        this.onTextChange = this.onTextChange.bind(this);
        this.buttonClick = this.buttonClick.bind(this);
    }

    public render() {
        return (<div className='static-modal'>
            <Modal.Dialog>
                <Modal.Header closeButton onClick={this.props.cancelClick}>
                    <Modal.Title>Person</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <form>
                        <FormGroup>
                            <ControlLabel>Title</ControlLabel>
                            <input type='text' onChange={this.onTextChange}
                                value={this.state.person!.Title}
                                name='FirstName' className='form-control' />
                        </FormGroup>
                        <FormGroup>
                            <ControlLabel>Person Type</ControlLabel>
                            <input type='text' onChange={this.onTextChange}
                                value={this.state.person!.PersonType}
                                name='FirstName' className='form-control' />
                        </FormGroup>
                        <FormGroup validationState={this.getValidationState('FirstName')}>
                            <ControlLabel>FirstName</ControlLabel>
                            <input type='text' onChange={this.onTextChange}
                                value={this.state.person!.FirstName}
                                name='FirstName' className='form-control' />
                            <HelpBlock>{this.getValidationMessage('FirstName')}</HelpBlock>
                        </FormGroup>
                        <FormGroup validationState={this.getValidationState('LastName')} >
                            <ControlLabel>Lastname</ControlLabel>
                            <input type='text' onChange={this.onTextChange}
                                value={this.state.person!.LastName}
                                name='LastName' className='form-control' />
                            <HelpBlock>{this.getValidationMessage('LastName')}</HelpBlock>
                        </FormGroup>
                    </form>      
                    
                    <EmailAddressTable
                        EmailAddresses={this.state.person!.EmailAddresses}
                        DeleteClick={this.deleteMail}
                        EditClick={this.editMail} />  
                    
                </Modal.Body>
                <Modal.Footer>
                    <button type='button'
                        className={this.props.buttonType === 'edit' ? 'btn btn-default btn-sm' : 'btn btn-default btn-sm'}
                        onClick={this.buttonClick}>
                        <i className='material-icons'>save</i>
                    </button>
                    <button type='button'
                        className='btn btn-default btn-sm'
                        onClick={this.props.cancelClick}>
                        <i className='material-icons'>reply</i>
                    </button>
                </Modal.Footer>
            </Modal.Dialog>
        </div>);
    }


    public async deleteMail(mail: EmailAddress) {
        alert('deleteMail');
        //await Http.delete(`${Endpoints.Person}${person.Id}`);
        //await this.load();
    }

    public editMail(mail: EmailAddress) {
        alert('editMail');
        //const validationResult = {} as ValidationResult;
        //validationResult.IsValid = true;
        //this.setState({ showPersonForm: true, personFormModel: person, personFormButtonType: 'edit', validationResult: validationResult });
    }


    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        this.props.buttonClick(this.state.person!);
    }

    public componentWillReceiveProps(props: PersonFormProps) {
        this.state = { person: props.person ? { ...props.person } : { Id: '', Title: '', PersonType: '', FirstName: '', LastName: '', EmailAddresses: [] }, validationResult: props.validationResult };
    }

    public onTextChange(e: any) {
        const person: any = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({ person });
    }

    private getValidationState(formGroupKey: String): String {
        let state = '';
        const errors = this.state.validationResult!.Errors;
        if (errors !== undefined) {
            var error = errors.filter(elem => elem.PropertyName === formGroupKey)[0];
            if (error !== undefined) {
                state = error.ErrorCode;
            }
        }
        return state;
    }
    private getValidationMessage(formGroupKey: String): String {
        let message = '';
        const errors = this.state.validationResult!.Errors;
        if (errors !== undefined) {
            var error = errors.filter(elem => elem.PropertyName === formGroupKey)[0];
            if (error !== undefined) {
                message = error.ErrorMessage;
            }
        }
        return message;
    }
}

