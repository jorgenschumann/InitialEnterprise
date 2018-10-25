import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { CurrencyMain } from './components/currency/CurrencyMain';
import { PersonMain } from './components/person/PersonMain';
import { LoginForm } from './components/login/LoginForm';
import { RegisterForm } from './components/register/RegisterForm';
import { Main } from './components/test/Main';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/LoginForm' component={LoginForm} />
    <Route exact path='/RegisterForm' component={RegisterForm} />
    <Route path='/CurrencyMain' component={CurrencyMain} />
    <Route path='/PersonMain' component={PersonMain} /> 
    <Route path='/Main' component={Main} /> 
</Layout>;
