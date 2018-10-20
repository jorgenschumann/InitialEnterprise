import * as React from 'react';
import { Button, Modal } from 'react-bootstrap';
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
          <Modal.Header>
            <Modal.Title>Person</Modal.Title>
          </Modal.Header>
          <Modal.Body>
          <form>
                <input className='form-control'
                    name='firstName'
                    onChange={this.onTextChange}
                    type='text'
                    value={this.state.person.firstName} />
                <input
                    name='lastName'
                    onChange={this.onTextChange}
                    className='form-control'
                    type='text'
                    value={this.state.person.lastName} />
            </form>
          </Modal.Body>
          <Modal.Footer>
            <button type='button'
                className={this.props.buttonType === 'edit' ? 'btn btn-success' : 'btn btn-primary'}
                onClick={this.buttonClick}>{this.props.buttonType === 'edit' ? 'Update' : 'Add'}
            </button>
            <button type='button'
                className='btn btn-danger'
                onClick={this.props.cancelClick}>
                Cancel
            </button>
          </Modal.Footer>
        </Modal.Dialog>
      </div>);
    }

    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        this.props.buttonClick(this.state.person);
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

