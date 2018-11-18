import * as React from 'react';
import { Alert, Button } from 'react-bootstrap';

export interface AlertState {
    show: boolean;
}

export interface AlertProps {
    message: String |undefined;
    style: String | undefined; // "success", "warning", "danger", "info"
}


export class AlertComponent extends React.Component<AlertProps, Partial<AlertState>> {
    constructor(props, context) {
        super(props, context);

        this.handleDismiss = this.handleDismiss.bind(this);
        this.handleShow = this.handleShow.bind(this);

        this.state = {
            show: true
        };
    }

   public handleDismiss() {
        this.setState({ show: false });
    }

   public handleShow() {
        this.setState({ show: true });
    }

    public render() {
       return  this.state.show ?            
           <Alert bsStyle={this.props.style} className="alert-bottom" onDismiss={this.handleDismiss}>
               <h4>{this.props.message}</h4>    
            </Alert> :<div></div>            
        }       
}
