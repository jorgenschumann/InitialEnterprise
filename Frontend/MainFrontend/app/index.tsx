import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import App from './containers/App';
import * as RoutesModule from './routes';
const routes = RoutesModule.routes;

const rootEl = document.getElementById('app');

ReactDOM.render(
  <AppContainer>
    <BrowserRouter children={ routes } basename='http://localhost:8080/' />
  </AppContainer>,
  rootEl
);

// Hot Module Replacement API
if (module.hot) {
  module.hot.accept('./containers/App', () => {
    const NextApp = require<RequireImport>('./containers/App').default;
    ReactDOM.render(
      <AppContainer>
        <NextApp />
      </AppContainer>,
      rootEl
    );
  });
}
