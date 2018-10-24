import * as React from 'react';
import { Alert, Button } from 'react-bootstrap';
import Snackbar from 'material-ui/Snackbar';

// https://medium.freecodecamp.org/how-to-show-informational-messages-using-material-ui-in-a-react-web-app-5b108178608

let openSnackbarFunc;
export interface NotifierState {
    open: boolean;
    message: String;
}

interface NotfierProps {
    message: String;
}

export class Notifier extends React.Component<NotfierProps, Partial<NotifierState>> {
    state = {
        open: false,
        message: '',
    };

    public componentDidMount() {
        openSnackbarFunc = this.openSnackbar;
    }

    public openSnackbar = ({ message }) => {
        this.setState({
            open: true,
            message,
        });
    };

    public handleSnackbarClose = () => {
        this.setState({
            open: false,
            message: '',
        });
    };

    public function openSnackbar({ message }) {
        openSnackbarFunc({ message });
    }

    public render() {
        const message = (
            <span
                id="snackbar-message-id"
                dangerouslySetInnerHTML={{ __html: this.state.message }} />
        );

        return (
            <Snackbar
                anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
                message={message}
                autoHideDuration={3000}
                onClose={this.handleSnackbarClose}
                open={this.state.open}
                SnackbarContentProps={{
                    'aria-describedby': 'snackbar-message-id',
                }}
            />
        );
    }
}




