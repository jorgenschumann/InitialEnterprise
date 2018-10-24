import * as React from 'react';
import { Button, ControlLabel, Modal } from 'react-bootstrap';
import {
    Currency as CurrencyEntity,
    CurrencyFormButtonType,
    CurrencyInterface
} from './types';


// tslint:disable-next-line:interface-name
interface CurrencyFormProps {
    currency?: CurrencyEntity;
    buttonClick: (Currency: CurrencyEntity) => void;
    buttonType: CurrencyFormButtonType;
    cancelClick: () => void;
}

export class CurrencyForm extends React.Component<CurrencyFormProps, Partial<CurrencyInterface>> {
    constructor(props: CurrencyFormProps) {
        super(props);
        this.onTextChange = this.onTextChange.bind(this);
        this.buttonClick = this.buttonClick.bind(this);
        this.state = {
             currency: props.currency ? { ...props.currency } : { id: '', name: '', isoCode: '', rates: [] }
        };
    }

   // tslint:disable-next-line:member-ordering
   public componentWillReceiveProps(props: CurrencyFormProps) {
       this.setState({ currency: props.currency ? { ...props.currency } : { id: '', name: '', isoCode: '', rates: [] } });
   }

   public render() {
       return (<div className='static-modal'>
           <Modal.Dialog>
               <Modal.Header closeButton onClick={this.props.cancelClick}>
                   <Modal.Title>Currency</Modal.Title>
               </Modal.Header>
               <Modal.Body>
                   <form>
                       <ControlLabel>Name</ControlLabel>
                       <input className='form-control'
                           name='firstName'
                           onChange={this.onTextChange}
                           type='text'
                           value={this.state.currency!.name} />
                       <br/>
                       <ControlLabel>IsoCode</ControlLabel>
                       <input
                           name='lastName'
                           onChange={this.onTextChange}
                           className='form-control'
                           type='text'
                           value={this.state.currency!.isoCode} />
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

   private buttonClick(evt: React.MouseEvent<HTMLButtonElement>) {
        evt.preventDefault();
        // this.props.buttonClick(this.state.currency);
    }

   private  onTextChange(e: any) {
        const currency: any = this.state.currency;
        currency[e.target.name] = e.target.value;
        this.setState({ currency });
    }
}
