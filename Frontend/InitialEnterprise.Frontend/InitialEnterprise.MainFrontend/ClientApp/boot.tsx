import './css/site.css';
import '../node_modules/react-bootstrap-table/dist/react-bootstrap-table-all.min.css';
//import '../node_modules/bootstrap/dist/css/bootstrap.min.css';



import 'bootstrap';
import axios from 'axios';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import * as RoutesModule from './routes';
import { Endpoints } from './components/Endpoints';
import { authHeader } from './auth-header';
let routes = RoutesModule.routes;

function renderApp() {    

    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;

    axios.defaults.baseURL = Endpoints.Api;    
    axios.defaults.headers.post['Content-Type'] = 'application/json';


    ReactDOM.render(
        <AppContainer>
            <BrowserRouter children={ routes } basename={ baseUrl } />
        </AppContainer>,
        document.getElementById('react-app')
    );  
  
}

renderApp();

if (module.hot) {
    module.hot.accept('./routes', () => {
        routes = require<typeof RoutesModule>('./routes').routes;
        renderApp();
    });
}