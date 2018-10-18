import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavigationMenu extends React.Component<{}, {}> {
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
                    <Link className='navbar-brand' to={'/'}>Main BoundedContext</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>   
                        <li>
                            <NavLink to={'/LoginForm'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Login
                            </NavLink>
                        </li>                                       
                        <li>
                            <NavLink to={'/CurrencyMain'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Currencies
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/PersonMain'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Personen
                            </NavLink>
                        </li>

                        <li>
                            <NavLink to={'/Main'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Main Personen
                            </NavLink>
                        </li>
                    </ul>
                </div>                
            </div>
        </div>;
    }
}
