import * as React from 'react';
import { Route } from 'react-router-dom';
import { Home } from './components/Home';
import { Layout } from './components/Layout';

import { CurrencyMain } from './components/currency/CurrencyMain';
import { LoginForm } from './components/login/LoginForm';
import { PersonMain } from './components/person/PersonMain';
import { RegisterForm } from './components/register/RegisterForm';

export const routes = <Layout>
    <Route path='/Home' component={Home} />
    <Route path='/CurrencyMain' component={CurrencyMain} />
    <Route path='/PersonMain' component={PersonMain} />
    <Route path='/LoginForm' component={LoginForm} />
    <Route path='/RegisterForm' component={RegisterForm} />
</Layout>;
