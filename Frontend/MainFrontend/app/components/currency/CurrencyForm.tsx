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
                <Modal
                    show={this.props.showCurrencyForm}
                    container={this}
                    aria-labelledby='contained-modal-title'>
                    <Modal.Header closeButton>
                        <Modal.Title id='contained-modal-title'>
                            Contained Modal
            </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        Elit est explicabo ipsum eaque dolorem blanditiis doloribus sed id
                        ipsam, beatae, rem fuga id earum? Inventore et facilis obcaecati.
          </Modal.Body>
                    <Modal.Footer>
                        <Button>Close</Button>
                    </Modal.Footer>
                </Modal>
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
