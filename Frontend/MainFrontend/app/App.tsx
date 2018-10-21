// // import * as React from 'react';

// // export default class App extends React.Component<any, any> {
// //     private interval: number;
// //     constructor() {
// //         super();
// //         this.state = { count: 0 };
// //     }

// //     // This state will be maintained during hot reloads
// //     public componentWillMount() {
// //         this.interval = setInterval(() => {
// //             this.setState({ count: this.state.count + 1 });
// //         }, 1000);
// //     }

// //     public componentWillUnmount() {
// //         clearInterval(this.interval);
// //     }

// //     public render() {
// //         return (
// //             <div>
// //                 <h1>Hello world!</h1>
// //                 <div>Welcome to hot-reloading React written in TypeScript! {this.state.count}</div>
// //             </div>
// //         );
// //     }
// // }


// import '../node_modules/react-bootstrap-table/dist/react-bootstrap-table-all.min.css';
// import './css/site.css';

// import 'bootstrap';
// import * as React from 'react';
// import * as ReactDOM from 'react-dom';
// import { AppContainer } from 'react-hot-loader';
// import { BrowserRouter } from 'react-router-dom';
// import * as RoutesModule from './routes';
// let routes = RoutesModule.routes;

// function renderApp() {

//     const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;

//     ReactDOM.render(
//         <AppContainer>
//             <BrowserRouter children={ routes } basename={ baseUrl } />
//         </AppContainer>,
//         document.getElementById('react-app')
//     );
// }

// renderApp();

// if (module.hot) {
//     module.hot.accept('./routes', () => {
//         routes = require<typeof RoutesModule>('./routes').routes;
//         renderApp();
//     });
// }

