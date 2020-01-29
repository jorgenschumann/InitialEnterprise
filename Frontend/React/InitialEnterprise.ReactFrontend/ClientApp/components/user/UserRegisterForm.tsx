import axios from 'axios';
import * as React from 'react';
import { Button, Modal, FormGroup, ControlLabel, FormControl} from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { Endpoints } from '../Endpoints';
import { Register as RegisterEntity } from './types';
import { Http } from '../Http';

// tslint:disable-next-line:interface-name
interface RegisterFormInterface {
    register?: RegisterEntity;
    show: boolean;
}

export class UserRegisterForm extends React.Component<RouteComponentProps<{}>, Partial<RegisterFormInterface>> {
    constructor() {
        super();

        this.state = { register: { UserName: '', Email: '', Password: '', ConfirmPassword: '' }, show: true };

        this.onTextChange = this.onTextChange.bind(this);
        this.register = this.register.bind(this);
    }
       
    public render() {
        return (<div>
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
                                    <FormControl type='text' value={this.state.register!.UserName} onChange={this.onTextChange}
                                        placeholder="Username" className='form-control' name='UserName'/>
                                </FormGroup> 
                                <FormGroup>
                                    <ControlLabel>Email</ControlLabel>
                                    <FormControl type='text' value={this.state.register!.Email} onChange={this.onTextChange}
                                        placeholder="Email" className='form-control' name='Email'/>
                                </FormGroup>   
                                <FormGroup>
                                    <ControlLabel>Password</ControlLabel>
                                    <FormControl type='password' value={this.state.register!.Password} onChange={this.onTextChange}
                                        placeholder="Password" className='form-control' name='Password'/>
                                </FormGroup> 
                                <FormGroup>
                                    <ControlLabel>ConfirmPassword</ControlLabel>
                                    <FormControl type='password' value={this.state.register!.ConfirmPassword} onChange={this.onTextChange}
                                        placeholder="Confirm Password" className='form-control' name='ConfirmPassword'/>
                                </FormGroup> 
                            </form>
                        </Modal.Body>
                        <Modal.Footer>                            
                            <button type='submit' className='btn btn-default' onClick={() => this.register()}>Register</button>
                            <button className='btn btn-default' onClick={() => this.closeDialog()}>Cancel</button>
                        </Modal.Footer>
                    </Modal.Dialog>
                </div>
            </div>)
    }
    
    private async register() {
        const register: any = this.state.register;
        await Http.post(Endpoints.UserAccountRegister, register).then((response) => {
            this.setState({ register: response.data });
            alert(JSON.stringify(response.data));
        });         
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
