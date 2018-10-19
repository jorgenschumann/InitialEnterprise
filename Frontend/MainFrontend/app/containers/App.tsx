import * as React from 'react';

export default class App extends React.Component<any, any> {
    constructor() {
        super();
        this.state = { count: 0 };
    }

    public render() {
        return (
            <div>
                <h1>Hello world!</h1>
            </div>
        );
    }
}
