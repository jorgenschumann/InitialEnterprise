import * as React from 'react';
import { Alert, Button } from 'react-bootstrap';

export interface AlertState {
    show: boolean;
}

interface AlertProps {
    message: String;
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
        if (this.state.show) {
            return (
                <Alert bsStyle="danger" onDismiss={this.handleDismiss}>
                    <h4>You got an error!</h4>            
                    <p>                      
                        <Button onClick={this.handleDismiss}>Hide Alert</Button>
                    </p>
                </Alert>
            );
        }
        return <Button onClick={this.handleShow}>Show Alert</Button>;
    }
}
