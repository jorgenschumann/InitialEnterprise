import * as React from "react";
import axios from 'axios';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { Link } from 'react-router-dom';
import { Button, Modal } from 'react-bootstrap';
import { Register as RegisterEntity } from './types';

interface RegisterFormInterface {
    register?: RegisterEntity;
    show: boolean;
}

export class RegisterForm extends React.Component<undefined, Partial<RegisterFormInterface>> {
    constructor() {
        super();

        this.state = { register: { UserName: '', Email: '', Password: '', ConfirmPassword: '' }, show: true }

        this.onTextChange = this.onTextChange.bind(this);
        this.register = this.register.bind(this);
    }

    private register = () => {
        alert(JSON.stringify(this.state));
    }

    private onTextChange(e: any) {
        let person: any = this.state.register;
        person[e.target.name] = e.target.value;
        this.setState({ register: person });
    }

    public render() {
        const { show } = this.state;
        return (
            <div className="static-modal">
                <Modal
                    show={show}
                    container={this}
                    aria-labelledby="contained-modal-title">
                    <Modal.Header >
                        <Modal.Title id="contained-modal-title">
                            Register
                            </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <div className='form-group' >
                            <label htmlFor="email">UserName</label>
                            <input type="text" className="form-control" name="UserName" onChange={this.onTextChange} />
                        </div >
                        <div className='form-group' >
                            <label htmlFor="email">EMail</label>
                            <input type="text" className="form-control" name="EMail" onChange={this.onTextChange} />
                        </div >
                        <div className='form-group' >
                            <label htmlFor="password">Password</label>
                            <input type="password" className="form-control" name="Password" onChange={this.onTextChange} />
                        </div>
                        <div className='form-group' >
                            <label htmlFor="Confirmpassword">Confirm Password</label>
                            <input type="password" className="form-control" name="ConfirmPassword" onChange={this.onTextChange} />
                        </div>
                    </Modal.Body>
                    <Modal.Footer>
                        <button className="btn btn-primary" onClick={this.register}>Register</button>
                        <Button onClick={() => this.setState({ show: false })}>Cancel</Button>
                    </Modal.Footer>
                </Modal>
            </div>);
    }
}
