import * as React from "react";
import { PersonEntity as PersonEntity } from './PersonEntity';
import {PersonFormButtonType, PersonInterface} from './types';
import { render } from "react-dom";

interface PersonFormProps {
    person?: PersonEntity;
    buttonClick: (person: PersonEntity) => void;
    buttonType: PersonFormButtonType;
    cancelClick: () => void;
}

export class PersonForm extends React.Component<PersonFormProps, Partial<PersonInterface>> {
    constructor(props: PersonFormProps){
        super(props);
        this.onTextChange = this.onTextChange.bind(this);
        this.buttonClick = this.buttonClick.bind(this);
        this.state = {
            person: props.person ? {...props.person} : {id: 0, firstName: '', lastName: '', age: 0}
        }
    }

    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        this.props.buttonClick(this.state.person!);
    }

    async componentDidMount() {
        alert('PersonForm.componentDidMount')
        this.render();
    }

    componentWillMount() {
        alert('PersonForm.componentWillMount')
    }

    componentWillUnmount() {
        alert('PersonForm.componentWillUnmount')
    }

    public componentWillReceiveProps(props: PersonFormProps) {
        this.setState({person: props.person ? {...props.person} : {id: 0, firstName: '', lastName: '', age: 0}});
    }

   private onTextChange(e: any) {
        let person:any = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({person});
    }

    public render() {
        return (
            <form>
                <input className='form-control' 
                    name='firstName'
                    onChange={this.onTextChange} 
                    type='text' 
                    value={this.state.person!.firstName} />
                <input 
                    name='lastName'
                    onChange={this.onTextChange} 
                    className='form-control' 
                    type='text' 
                    value={this.state.person!.lastName} />              
                <button 
                    className={this.props.buttonType == 'edit' ? 'btn btn-success': 'btn btn-primary'}
                    onClick={this.buttonClick}>
                    {this.props.buttonType == 'edit' ? 'Update': 'Add'}
                </button>
                <button type='button'
                    className='btn btn-danger'
                    onClick={this.props.cancelClick}>
                    Cancel
                </button>
            </form>
        )
    }
}