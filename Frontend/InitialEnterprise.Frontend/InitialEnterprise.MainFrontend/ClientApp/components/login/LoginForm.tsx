import * as React from 'react';
import axios from 'axios';
import { Button, Modal,FormGroup ,InputGroup , FormControl, ControlLabel} from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { Endpoints } from '../Endpoints';
import { Login } from './types';


// tslint:disable-next-line:interface-name
interface LoginFormInterface {
    show: boolean;
    login?: Login;
}

export class LoginForm extends React.Component<RouteComponentProps<{}>, Partial<LoginFormInterface>> {
    constructor() {
        super();

        this.state = { login: { Email: '', Password: ''}, show: true };

        this.onTextChange = this.onTextChange.bind(this);
        this.signinUser = this.signinUser.bind(this);
    }

    public render() {
        return (
            <div>
                <div className='static-modal'>
                <Modal.Dialog>
                <Modal.Header closeButton onClick={() => this.closeDialog()}>
                        <Modal.Title id='contained-modal-title'>
                            Login
                        </Modal.Title>
                    </Modal.Header>
                        <Modal.Body> 
                        <form >
                            <FormGroup>        
                                <ControlLabel>Email</ControlLabel> 
                                <FormControl type='text'placeholder="Email" className='form-control' name='Email' onChange={this.onTextChange} />  
                            </FormGroup>  
                            <FormGroup>     
                                <ControlLabel>Password</ControlLabel>                                                                                 
                                <FormControl  type='password' placeholder="Password" className='form-control' name='Password' onChange={this.onTextChange} />  
                            </FormGroup> 
                        </form>  
                    </Modal.Body>
                    <Modal.Footer>
                        <Link to='/RegisterForm' className='btn btn-link'>Register</Link>
                        <button type='submit' className='btn btn-default btn-sm' onClick={() => this.signinUser()}>Login</button>
                        <button className='btn btn-default btn-sm' onClick={()=>this.closeDialog()}>Cancel</button>
                    </Modal.Footer>
                </Modal.Dialog>
            </div>
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
        const result = await axios.post(Endpoints.UserAccountSignin, login);    
        this.setState({  login });
    }

    private closeDialog() {
        this.setState({ show: false });
    }
}
