import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { CurrencyMain } from './components/currency/CurrencyMain';
import { PersonMain } from './components/person/PersonMain';
import { UserLoginForm } from './components/user/UserLoginForm';
import { UserRegisterForm } from './components/user/UserRegisterForm';
import { UserForm } from './components/user/UserForm';
import { Main } from './components/test/Main';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/UserForm' component={UserForm} />
    <Route exact path='/UserLoginForm' component={UserLoginForm} />
    <Route exact path='/UserRegisterForm' component={UserRegisterForm} />
    <Route path='/CurrencyMain' component={CurrencyMain} />
    <Route path='/PersonMain' component={PersonMain} /> 
    <Route path='/Main' component={Main} /> 
</Layout>;
