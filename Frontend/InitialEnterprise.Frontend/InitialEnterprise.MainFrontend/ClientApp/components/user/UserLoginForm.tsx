import * as React from 'react';
import axios, { AxiosResponse } from 'axios';
import { Button, Modal,FormGroup ,InputGroup , FormControl, ControlLabel} from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Link, Redirect } from 'react-router-dom';
import { Endpoints } from '../Endpoints';
import { Login } from './types';
import { Http } from '../Http';


// tslint:disable-next-line:interface-name
interface LoginFormInterface {
    show: boolean;
    login?: Login;
    shouldRedirect: boolean;
}

export class UserLoginForm extends React.Component<RouteComponentProps<{}>, Partial<LoginFormInterface>> {
    constructor() {
        super();
        
        this.state = { login: { Email: '', Password: '' }, show: true, shouldRedirect : false };

        this.onTextChange = this.onTextChange.bind(this);
        this.signinUser = this.signinUser.bind(this);
    }

    public render() {
        return (
            <div>
                {this.state.shouldRedirect ?
                    <Redirect to="/home" push /> :
                    <div className='static-modal'>
                        <Modal.Dialog>
                            <Modal.Header closeButton onClick={() => this.closeDialog}>
                                <Modal.Title id='contained-modal-title'>
                                    Login
                        </Modal.Title>
                            </Modal.Header>
                            <Modal.Body>
                                <form >
                                    <FormGroup>
                                        <ControlLabel>Email</ControlLabel>
                                        <FormControl type='text' placeholder="Email" className='form-control' name='Email'
                                            value={this.state.login!.Email} onChange={this.onTextChange} />
                                    </FormGroup>
                                    <FormGroup>
                                        <ControlLabel>Password</ControlLabel>
                                        <FormControl type='password' placeholder="Password" className='form-control' name='Password'
                                            value={this.state.login!.Password} onChange={this.onTextChange} />
                                    </FormGroup>
                                </form>
                            </Modal.Body>
                            <Modal.Footer>
                                <Link to='/UserRegisterForm' className='btn btn-link'>Register</Link>
                                <button type='submit' className='btn btn-default' onClick={() => this.signinUser()}>Login</button>
                                <button className='btn btn-default' onClick={() => this.closeDialog()}>Cancel</button>
                            </Modal.Footer>
                        </Modal.Dialog>
                    </div>
                }
           </div>                   
        );
    }

    private onTextChange(e: any) {
        const login: any = this.state.login;
        login[e.target.name] = e.target.value;
        this.setState({  login });
    }

    private async signinUser() {
        const login: any = this.state.login;
        const loginResult = await Http.post(Endpoints.UserAccountSignin, login); 
        localStorage.setItem('token', loginResult.data.Token);   
        this.setState({ login: login, shouldRedirect: Http.isAuthenticated() });    
   
    }

    private closeDialog() {
        this.setState({ show: false });
    }
}
