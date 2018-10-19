import axios from 'axios';
import * as React from 'react';
import { Button, Modal } from 'react-bootstrap';
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
        return ( <div>
               <p>login</p>
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
        this.setState({  login });
    }

    private closeDialog() {
        this.setState({ show: false });
    }
}
