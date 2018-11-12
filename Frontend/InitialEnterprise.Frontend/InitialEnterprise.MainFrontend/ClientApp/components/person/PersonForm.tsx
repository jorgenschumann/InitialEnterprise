import * as React from 'react';
import { ControlLabel, Modal, AlertComponent, FormGroup} from 'react-bootstrap';
import { Person as PersonEntity, MailAdresses, PersonFormButtonType, Person, ValidationResult, Model,  PersonFormState} from './types';

interface PersonFormProps {
    person?: PersonEntity;
    buttonClick: (person: PersonEntity) => void;
    buttonType: PersonFormButtonType;
    cancelClick: () => void;
}

export class PersonForm extends React.Component<PersonFormProps , Partial<PersonFormState>> {
    constructor(props: PersonFormProps) {
        super(props);
        this.state = { person: props.person ? { ...props.person } : { Id: '', FirstName: '', LastName: '' }};  
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
                        <ControlLabel>FirstName</ControlLabel>
                        <input type='text' onChange={this.onTextChange} value={this.state.person!.FirstName}
                               name='FirstName' className='form-control' />
                       </FormGroup>                         
                       <br />
                       <FormGroup>
                           <ControlLabel>Lastname</ControlLabel>
                           <input type='text' value={this.state.person!.LastName} onChange={this.onTextChange}
                               name='LastName' className='form-control' />
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

    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        this.props.buttonClick(this.state.person!);
    }

    public componentWillReceiveProps(props: PersonFormProps) {
        this.setState({ person: props.person ? { ...props.person } : { Id: '', FirstName: '', LastName: ''}});
    }

    public onTextChange(e: any) {
        const person: any = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({ person });
    }
}

