import * as React from "react";
import axios from 'axios';
import { Endpoints } from '../Endpoints';
import { CurrencyFormButtonType, CurrenciesInterface, Currency } from "./types";
import { CurrencyForm } from "./CurrencyForm";
import { CurrencyTable } from "../currency/CurrencyTable";
import { RouteComponentProps } from "react-router";
import { Button, Modal } from 'react-bootstrap';
import { BootstrapTable, TableHeaderColumn, SelectRow, Options, CellEdit } from 'react-bootstrap-table';

interface MainState {
    showCurrencyForm: boolean;
    currencyForm?: Currency;
    currencyFormButtonType: CurrencyFormButtonType
}

export class CurrencyMain extends React.Component<undefined, Partial<MainState & CurrenciesInterface>> {
    constructor() {
        super();
        this.state = { currencies: ([] as Currency[]), showCurrencyForm: false, currencyFormButtonType: 'add' };

        this.deleteClick = this.deleteClick.bind(this);
        this.editClick = this.editClick.bind(this);
        this.formButtonClick = this.formButtonClick.bind(this);
        this.newCurrencyClick = this.newCurrencyClick.bind(this);
        this.personFormCancelClick = this.personFormCancelClick.bind(this);     
    }

    async componentDidMount() {
        this.loadCurrencies();
    }

    async deleteClick(currency: Currency) {
        await axios.delete(`${Endpoints.Currency}${currency.Id}`);
        await this.loadCurrencies();
    }

    editClick(currency: Currency) {
        this.setState({ showCurrencyForm: true, currencyForm: currency, currencyFormButtonType: 'edit' });
    }

    async formButtonClick(currency: Currency) {
        let func = this.state.currencyFormButtonType === 'edit' ? axios.put : axios.post;
        await func(Endpoints.Currency, currency);
        await this.loadCurrencies();
        this.setState({ showCurrencyForm: false });
    }

    async loadCurrencies() {
        let currencies = await axios.get(Endpoints.Currency);
        this.setState({ currencies: currencies.data });
    }

    newCurrencyClick() {
        // this.setState({showPersonForm: true, personFormPerson: null, personFormButtonType: 'add'});
    }

    personFormCancelClick() {
        this.setState({ showCurrencyForm: false });
    }

    private deleteCurrency(rowKeys) {
        alert('The rowkey you drop: ' + rowKeys);
    }

    public render() {

        let options: Options = {
            afterDeleteRow: this.deleteCurrency,
            noDataText: 'no data',
            handleConfirmDeleteRow: this.customConfirm
        };

        let selectRow: SelectRow = {
            mode: 'checkbox'
        };       

        let cellEditProp: CellEdit= {
            mode: 'dbclick'
        };

        const createNameEditor = (onUpdate, props) => (<NameEditor onUpdate={onUpdate} {...props} />);
        
        return (
            <div className='container'>
                <h1>Currencies</h1>
                <BootstrapTable data={this.state.currencies!} cellEdit={cellEditProp}              
                    pagination
                    search={true}
                    insertRow
                    deleteRow={true}
                    exportCSV
                    options={options}
                    selectRow={selectRow}>
                    <TableHeaderColumn dataField='id' hidden isKey={true}>ID</TableHeaderColumn>
                    <TableHeaderColumn dataField='name' customEditor={{ getElement: createNameEditor }}>Name</TableHeaderColumn>
                    <TableHeaderColumn dataField='isoCode'>IsoCode</TableHeaderColumn>
                </BootstrapTable>

            </div>);
    }

   
    private customConfirm(next, dropRowKeys) {
        let dropRowKeysStr = dropRowKeys.join(',');
        if (confirm(`Are you sure you want to delete ${dropRowKeysStr}?`)) {
            next();
        }
    } 
}

interface CurrencyFormProps {  
    currency?: Currency;     
    editorClass: string;
}

interface NameEditorState {
    open: boolean; 
    name: string;
}

class NameEditor extends React.Component<CurrencyFormProps, NameEditorState> {
    constructor(props) {
        super(props);
        this.updateData = this.updateData.bind(this);
        this.state = {
            name: props.defaultValue, open: true
        };
    }
    focus() {
        //this.refs.inputRef.focus();
    }
    updateData() {
        //this.props.onUpdate(this.state.name);
    }
    close = () => {
        this.setState({ open: false });
        //this.props.onUpdate(this.props.defaultValue);
    }
    render() {
        const fadeIn = this.state.open ? 'in' : '';
        const display = this.state.open ? 'block' : 'none';
        return (
            <div className={`modal fade ${fadeIn}`} id='myModal' role='dialog' style={{ display }}>
                <div className='modal-dialog'>
                    <div className='modal-content'>
                        <div className='modal-body'>
                            <input
                                ref='inputRef'
                                className={(this.props.editorClass || '') + ' form-control editor edit-text'}
                                style={{ display: 'inline', width: '50%' }}
                                type='text'
                                value={this.state.name}
                                onChange={e => { this.setState({ name: e.currentTarget.value }); }} />
                        </div>
                        <div className='modal-footer'>
                            <button type='button' className='btn btn-primary' onClick={this.updateData}>Save</button>
                            <button type='button' className='btn btn-default' onClick={this.close}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}