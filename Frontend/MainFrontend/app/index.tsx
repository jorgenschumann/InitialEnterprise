
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import { Endpoints } from './Components/Endpoints';
import * as RoutesModule from './routes';
const routes = RoutesModule.routes;
import App from './containers/App';
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;

function renderApp() {
  // tslint:disable-next-line:no-shadowed-variable
  const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;

  ReactDOM.render(
        <AppContainer>
            <BrowserRouter children={ routes } basename={ baseUrl } />
        </AppContainer>,
        document.getElementById('react-app')
    );
}

renderApp();

// if (module.hot) {
//     module.hot.accept('../app/routes', () => {
//         routes = require<typeof RoutesModule>('../app/routes').routes;
//         renderApp();
//     });
// }
