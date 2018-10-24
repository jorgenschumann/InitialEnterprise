import * as React from 'react';
import {  ControlLabel, Modal } from 'react-bootstrap';
import { Person as PersonEntity, PersonFormButtonType, PersonInterface} from './types';

// tslint:disable-next-line:interface-name
interface PersonFormProps {
    person?: PersonEntity;
    buttonClick: (person: PersonEntity) => void;
    buttonType: PersonFormButtonType;
    cancelClick: () => void;
}

export class PersonForm extends React.Component<PersonFormProps, Partial<PersonInterface>> {
    constructor(props: PersonFormProps) {
        super(props);
        this.onTextChange = this.onTextChange.bind(this);
        this.buttonClick = this.buttonClick.bind(this);
        this.state = {
            person: props.person ? { ...props.person } : { id: '', firstName: '', lastName: '' }
        };
    }

   public render() {
       return (
        <div className='static-modal'>
        <Modal.Dialog>
            <Modal.Header closeButton onClick={this.props.cancelClick}>
                <Modal.Title>Person</Modal.Title>
          </Modal.Header>
          <Modal.Body>
          <form>
          <ControlLabel>FirstName</ControlLabel>
                <input className='form-control'
                    name='firstName'
                    onChange={this.onTextChange}
                    type='text'
                               value={this.state.person!.firstName} />
                <br/>
               <ControlLabel>Lastname</ControlLabel>
                <input
                    name='lastName'
                    onChange={this.onTextChange}
                    className='form-control'
                    type='text'
                               value={this.state.person!.lastName} />
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
        this.setState({ person : props.person ? {...props.person} : {id: '', firstName: '', lastName: ''}});
    }

    public onTextChange(e: any) {
        const person: any = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({ person });
    }
}

