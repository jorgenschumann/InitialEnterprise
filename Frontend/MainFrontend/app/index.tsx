import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import * as RoutesModule from './routes';
const routes = RoutesModule.routes;

const rootEl = document.getElementById('app');
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;

ReactDOM.render(
  <AppContainer>
    <BrowserRouter children={ routes } basename={baseUrl} />
  </AppContainer>,
  rootEl
);


if (module.hot) {
  module.hot.accept('./', () => {
    const NextApp = require<RequireImport>('./').default;
    ReactDOM.render(
      <AppContainer>
        <NextApp />
      </AppContainer>,
      rootEl
    );
  });
}
