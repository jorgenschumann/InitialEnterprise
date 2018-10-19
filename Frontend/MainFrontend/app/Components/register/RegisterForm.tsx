import axios from 'axios';
import * as React from 'react';
import { Button, Modal } from 'react-bootstrap';
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
        const { show } = this.state;
        return (
            <div className='static-modal'>
            </div>);
    }

    private register = () => {
        alert(JSON.stringify(this.state));
    }

    private onTextChange(e: any) {
        const person: any = this.state.register;
        person[e.target.name] = e.target.value;
        this.setState({ register: person });
    }
}
