import * as React from 'react';
import { Button, Modal } from 'react-bootstrap';
import {
    Currency as CurrencyEntity,
    CurrencyFormButtonType,
    CurrencyInterface
} from './types';


// tslint:disable-next-line:interface-name
interface CurrencyFormProps {
    // tslint:disable-next-line:ban-types
    showCurrencyForm: Boolean;
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
             currency: props.currency ? { ...props.currency } : { Id: '', Name: '', IsoCode: '', Rates: [] }
        };
    }

   // tslint:disable-next-line:member-ordering
   public componentWillReceiveProps(props: CurrencyFormProps) {
        this.setState({ currency: props.currency ? { ...props.currency } : { Id: '', Name: '', IsoCode: '', Rates: [] } });
    }

   public render() {
        return (
            <div className='static-modal' >
             <p>currency</p>
            </div >);
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
