import axios from 'axios';
import * as React from 'react';
import { Button, Modal, FormGroup, ControlLabel, FormControl, Checkbox} from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { Endpoints } from '../Endpoints';
import { User as User, TokenDto } from './types';
import { Http } from '../Http';
import * as JWT from 'jwt-decode';

// tslint:disable-next-line:interface-name
interface UserFormInterface {
    user?: User;
    show: boolean;
}

export class UserForm extends React.Component<RouteComponentProps<{}>, Partial<UserFormInterface>> {
    constructor() {
        super();

        this.state = {
            user: {
                Id:'',
                UserName: '',
                Email: '',
                EmailConfirmed: '',
                Password: '',
                ConfirmPassword: '',
                PhoneNumber: '',
                PhoneNumberConfirmed: '',
                Claims: []
            }, show: true
        };

        this.onTextChange = this.onTextChange.bind(this);
        this.save = this.save.bind(this);
        this.closeDialog = this.closeDialog.bind(this);
    }

    public render() {
        return (
            <div>
                <div className='static-modal'>
                    <Modal.Dialog>
                        <Modal.Header closeButton onClick={this.closeDialog()}>
                            <Modal.Title id='contained-modal-title'>
                                User:{this.state.user!.Id}
                        </Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <form >                              
                                <FormGroup>
                                    <ControlLabel>Username</ControlLabel>
                                    <FormControl type='text' placeholder="Username" className='form-control' name='UserName'
                                        value={this.state.user!.UserName} onChange={this.onTextChange} />
                                </FormGroup>
                                <FormGroup>
                                    <ControlLabel>Email</ControlLabel>
                                    <FormControl type='text' placeholder="Email" className='form-control' name='Email'
                                        value={this.state.user!.Email} onChange={this.onTextChange} />
                                </FormGroup>                         
                                <FormGroup>
                                    <Checkbox  disabled value={this.state.user!.EmailConfirmed} inline>EmailConfirmed</Checkbox>
                                </FormGroup>    
                                <FormGroup>
                                    <ControlLabel>Password</ControlLabel>
                                    <FormControl type='password' placeholder="Password" className='form-control' name='Password'
                                        value={this.state.user!.Password} onChange={this.onTextChange} />
                                </FormGroup>                         
                                <FormGroup>
                                    <ControlLabel>ConfirmPassword</ControlLabel>
                                    <FormControl type='text' placeholder="Confirm Password" className='form-control' name='confirmPassword'
                                        value={this.state.user!.ConfirmPassword} onChange={this.onTextChange} />
                                </FormGroup>
                                <FormGroup>
                                    <ControlLabel>PhoneNumber</ControlLabel>
                                    <FormControl type='text' placeholder="PhoneNumber" className='form-control' name='phoneNumber'
                                        value={this.state.user!.PhoneNumber} onChange={this.onTextChange} />
                                </FormGroup>
                                <FormGroup>
                                    <Checkbox disabled value={this.state.user!.PhoneNumberConfirmed}  inline>PhoneNumberConfirmed</Checkbox>                                 
                                </FormGroup>                            
                              
                            </form>
                        </Modal.Body>
                        <Modal.Footer>
                            <button type='submit' className='btn btn-default' onClick={() => this.save}>Save</button>
                            <button className='btn btn-default' onClick={() => this.closeDialog()}>Cancel</button>
                        </Modal.Footer>
                    </Modal.Dialog>
                </div>
            </div>
        )
    }

    public async componentDidMount() {          
        const decodedToken = JWT<TokenDto>(Http.getToken()) as TokenDto;           
        this.read(decodedToken.Id);
    }
    
    public async read(id: string) {
        await Http.get(`${Endpoints.UserAccount}${id}`).then((response) => {
            this.setState({ user: response.data });  
        });       
    }

    private async save() {
        const user: any = this.state.user;
        await Http.put(Endpoints.UserAccount, user).then((response) => {
           this.setState({ user: response.data });  
            alert(JSON.stringify(response.data));
        });      
    }

    private closeDialog() {
        this.setState({ show: false });
    }

    private onTextChange(e: any) {
        const person: any = this.state.user;
        person[e.target.name] = e.target.value;
        this.setState({ user: person });
    }
}
