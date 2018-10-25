import axios from 'axios';
import * as React from 'react';
import { Button, Modal, FormGroup, ControlLabel, FormControl} from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { Endpoints } from '../Endpoints';
import { Register as RegisterEntity } from './types';

// tslint:disable-next-line:interface-name
interface RegisterFormInterface {
    register?: RegisterEntity;
    show: boolean;
}

export class RegisterForm extends React.Component<RouteComponentProps<{}>, Partial<RegisterFormInterface>> {
    constructor() {
        super();

        this.state = { register: { UserName: '', Email: '', Password: '', ConfirmPassword: '' }, show: true };

        this.onTextChange = this.onTextChange.bind(this);
        this.register = this.register.bind(this);
    }
       
    public render() {
        return (

            <div>
                <div className='static-modal'>
                    <Modal.Dialog>
                        <Modal.Header closeButton onClick={() => this.closeDialog()}>
                            <Modal.Title id='contained-modal-title'>
                                Register
                        </Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <form >
                                <FormGroup>
                                    <ControlLabel>Username</ControlLabel>
                                    <FormControl type='text' placeholder="Username" className='form-control' name='UserName' onChange={this.onTextChange} />
                                </FormGroup> 
                                <FormGroup>
                                    <ControlLabel>Email</ControlLabel>
                                    <FormControl type='text' placeholder="Email" className='form-control' name='Email' onChange={this.onTextChange} />
                                </FormGroup>   
                                <FormGroup>
                                    <ControlLabel>Password</ControlLabel>
                                    <FormControl type='password' placeholder="Password" className='form-control' name='Password' onChange={this.onTextChange} />
                                </FormGroup> 
                                <FormGroup>
                                    <ControlLabel>ConfirmPassword</ControlLabel>
                                    <FormControl type='password' placeholder="Confirm Password" className='form-control' name='ConfirmPassword' onChange={this.onTextChange} />
                                </FormGroup> 
                            </form>
                        </Modal.Body>
                        <Modal.Footer>                            
                            <button type='submit' className='btn btn-default' onClick={() => this.register()}>Register</button>
                            <button className='btn btn-default' onClick={() => this.closeDialog()}>Cancel</button>
                        </Modal.Footer>
                    </Modal.Dialog>
                </div>
            </div>
           )
    }

    private register = () => {
        alert(JSON.stringify(this.state));
    }

    private closeDialog() {
        this.setState({ show: false });
    }

    private onTextChange(e: any) {
        const person: any = this.state.register;
        person[e.target.name] = e.target.value;
        this.setState({ register: person });
    }
}
