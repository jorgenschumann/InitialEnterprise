import * as React from 'react';
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

    public buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        // this.props.buttonClick(this.state.person);
    }

    // componentWillReceiveProps(props: PersonFormProps) {
    //    this.setState({person: props.person ? {...props.person} : {id: 0, firstName: '', lastName: ''}});
    // }

    public onTextChange(e: any) {
        const person: any = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({ person });
    }
}

