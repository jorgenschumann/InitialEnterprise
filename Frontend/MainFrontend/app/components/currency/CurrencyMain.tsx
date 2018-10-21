import axios from 'axios';
import * as React from 'react';
import { Button, ButtonGroup, ButtonToolbar, Modal } from 'react-bootstrap';
import { RouteComponentProps } from 'react-router';
import { Endpoints } from '../Endpoints';
import { CurrencyForm } from './CurrencyForm';
import { CurrencyTable } from './CurrencyTable';
import { CurrenciesInterface, Currency, CurrencyFormButtonType } from './types';

// tslint:disable-next-line:interface-name
interface MainState {
    showCurrencyForm: boolean;
    currencyForm?: Currency;
    currencyFormButtonType: CurrencyFormButtonType;
}

export class CurrencyMain extends React.Component<RouteComponentProps<{}>, Partial<MainState & CurrenciesInterface>> {
    constructor() {
        super();
        this.state = { currencies: ([] as Currency[]), showCurrencyForm: false, currencyFormButtonType: 'add' };

        this.delete = this.delete.bind(this);
        this.edit = this.edit.bind(this);
        this.transfer = this.transfer.bind(this);
        this.create = this.create.bind(this);
        this.cancel = this.cancel.bind(this);
    }

    public async componentDidMount() {
        this.load();
    }

    public async delete(currency: Currency) {
        await axios.delete(`${Endpoints.Currency}${currency.id}`);
        await this.load();
    }

    public edit(currency: Currency) {
        this.setState({ showCurrencyForm: true, currencyForm: currency, currencyFormButtonType: 'edit' });
    }

    public async transfer(currency: Currency) {
        const func = this.state.currencyFormButtonType === 'edit' ? axios.put : axios.post;
        await func(Endpoints.Currency, currency);
        await this.load();
        this.setState({ showCurrencyForm: false });
    }

    public async load() {
        const currencies = await axios.get(Endpoints.Currency);
        this.setState({ currencies: currencies.data });
    }

    public create() {
        const currency = {} as Currency;
        this.setState({ showCurrencyForm: true, currencyForm: currency, currencyFormButtonType: 'add'});
    }

    public cancel() {
        this.setState({ showCurrencyForm: false });
    }


    public render() {

        return (
            <div className='container'>
                <h1>Currencies</h1>
                <ButtonToolbar>
                    <ButtonGroup bsSize='small'>
                        <button className='btn btn-default' onClick={this.load}><i className='material-icons'>autorenew</i></button>
                        <button className='btn btn-default' onClick={this.create}><i className='material-icons'>attach_money</i></button>
                    </ButtonGroup>
                </ButtonToolbar>
                <br />
                {this.state.showCurrencyForm && <CurrencyForm
                    currency={this.state.currencyForm}
                    buttonType={this.state.currencyFormButtonType}
                    buttonClick={this.transfer}
                    cancelClick={this.cancel} />}
                <CurrencyTable currencies={this.state.currencies}
                    deleteClick={this.delete}
                    editClick={this.edit} />
            </div>);
    }
}
