import * as React from 'react';
import { Button, ControlLabel, FormGroup, Modal } from 'react-bootstrap';
import { EmailAddress } from '../person/types';
import { MailFormButtonType, EmailAddressFormState } from './types';
import { ValidationResult } from '../types';


// tslint:disable-next-line:interface-name
interface EmailAddressFormProps {
    emailAddress?: EmailAddress;
    buttonClick: (emailAddress: EmailAddress) => void;
    buttonType: MailFormButtonType;
    cancelClick: () => void;
    validationResult?: ValidationResult;
}

export class EmailAddressForm extends React.Component<EmailAddressFormProps, Partial<EmailAddressFormState>> {
    constructor(props: EmailAddressFormProps & ValidationResult) {
        super(props);
        this.state = { emailAddress: props.emailAddress ? { ...props.emailAddress } : { Id: '', PersonId: '', MailAddress: '' }, validationResult: props.validationResult };
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
                                value={this.state.emailAddress!.MailAddress}
                                name='FirstName' className='form-control' />
                        </FormGroup>                       
                    </form>          

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
    
    public componentWillReceiveProps(props: EmailAddressFormProps) {
        this.state = { emailAddress: props.emailAddress ? { ...props.emailAddress } : { Id: '', PersonId: '', MailAddress: '' }, validationResult: props.validationResult };
    }

    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        this.props.buttonClick(this.state.emailAddress!);
    }

    public onTextChange(e: any) {
        const emailAddress: any = this.state.emailAddress;
        emailAddress[e.target.name] = e.target.value;
        this.setState({ emailAddress });
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