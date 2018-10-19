import * as React from 'react';
import { Route } from 'react-router-dom';
import { Home } from './components/Home';
import { Layout } from './components/Layout';

import { CurrencyMain } from './components/currency/CurrencyMain';
import { PersonMain } from './components/person/PersonMain';
// import { LoginForm } from './components/login/LoginForm';
// import { RegisterForm } from './components/register/RegisterForm';
// import { Main } from './components/test/Main';

export const routes = <Layout>
    <Route exact path='/Home' component={Home} />
    <Route exact path='/CurrencyMain' component={CurrencyMain} />
    <Route path='/PersonMain' component={PersonMain} />
    {/* <Route exact path='/LoginForm' component={LoginForm} />
    <Route exact path='/RegisterForm' component={RegisterForm} />    
    <Route path='/Main' component={Main} />  */}
</Layout>;
