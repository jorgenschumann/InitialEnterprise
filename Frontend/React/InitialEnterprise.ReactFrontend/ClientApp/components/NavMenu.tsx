import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Http } from './Http';

interface NavigationMenuState {
    showNavigation: boolean;
}

export class NavigationMenu extends React.Component<{}, {}> {
    constructor() {
        super();
        this.state = { showNavigation: false };
    }
    public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <NavLink className='navbar-brand' to={'/UserForm'}>My Account</NavLink>              
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>                      
                        <li>
                            <NavLink to={'/UserLoginForm'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Login
                            </NavLink>
                        </li>
                    </ul>
                </div>           
                {
                    Http.isAuthenticated() ?
                    <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/CurrencyMain'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Currencies
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/PersonMain'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> People
                            </NavLink>
                        </li>
                    </ul>
                    </div> :
                        <div></div>
                }        
            </div>
        </div>;
    }
}
