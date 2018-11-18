import * as React from 'react';
import { NavigationMenu } from './NavMenu';

// tslint:disable-next-line:interface-name
export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>                
                <div className='col-sm-3'>
                    <NavigationMenu />
                </div>
                <div className='col-sm-9'>
                    { this.props.children }
                </div>
            </div>
        </div>;
    }
}
