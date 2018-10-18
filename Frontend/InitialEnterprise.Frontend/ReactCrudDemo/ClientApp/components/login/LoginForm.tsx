import * as React from "react";
import axios from 'axios';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { Link } from 'react-router-dom';
import { Button, Modal } from 'react-bootstrap';
import { Login } from "./types";


interface LoginFormInterface {
    show: boolean;
    login?: Login;
}

export class LoginForm extends React.Component<undefined, Partial<LoginFormInterface>> {
    constructor(){
        super();

        this.state = { login: { Email: '', Password: ''}, show: true }

        this.onTextChange = this.onTextChange.bind(this);
        this.signinUser = this.signinUser.bind(this);
    }

    private onTextChange(e: any) {
        let login: any = this.state.login;     
        login[e.target.name] = e.target.value;
        this.setState({ login: login });
    }

    private async signinUser() {
        let login: any = this.state.login;      
        let loginResult = await axios.post(Endpoints.UserAccountSignin,JSON.stringify(login));
        this.setState({ login: login });
    } 

    private closeDialog() {
        this.setState({ show: false });
    }

    public render() {           
        return (
            <div>
                <div className="static-modal">
                    <Modal show={this.state.show} container={this} aria-labelledby="contained-modal-title">
                        <Modal.Header >
                            <Modal.Title id="contained-modal-title">
                                Login
                            </Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <div className="form-group">
                                <label htmlFor="password">Email</label>
                                <input type="text" className="form-control" name="EMail" onChange={this.onTextChange} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="password">Passwort</label>
                                <input type="password" className="form-control" name="Password" onChange={this.onTextChange} />
                            </div>
                        </Modal.Body>
                        <Modal.Footer>
                            <Link to="/RegisterForm" className="btn btn-link">Register</Link>
                            <button type="submit" className="btn btn-primary" onClick={this.signinUser}>Login</button>                        
                            <button className="btn btn-primary" onClick={() => this.closeDialog()}>Cancel</button>
                        </Modal.Footer>
                
                    </Modal>
                </div>
            </div>
        );
    }
}
