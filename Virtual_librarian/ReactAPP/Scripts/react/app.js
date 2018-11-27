import React from "react";
import ReactDOM from "react-dom";
import "./Components/LogedInPage/margins.css"
import {  Route} from "react-router";
import { HashRouter } from 'react-router-dom';
import { ApolloProvider } from 'react-apollo';
import ApolloClient from "apollo-boost";



import '@trendmicro/react-sidenav/dist/react-sidenav.css';
// Be sure to include styles at some point, probably during your bootstraping


//import Bootstrap from "./vendor/bootstrap-without-jquery";
import Home from "./Components/Home";
import Login from "./Components/authentication/SignIn";
import Layout from "./Components/LogedInPage/Layout";
import Footer from "./Components/LogedInPage/Footer/Footer";
import Register from "./Components/authentication/Register";
import LibraryHome from "./Components/LogedInPage/LibraryHome";

const client = new ApolloClient({
    uri: 'https://api-euwest.graphcms.com/v1/cjp05opy767ky01dgqqco0zjz/master',
});

const app = document.getElementById('app');

ReactDOM.render(
    <div >
        
        <HashRouter basename="/">
        <Layout>
                <ApolloProvider client={client}>
                    <Route exact path="/" render={props => <Login{...props} />} />
                    <Route exact path="/login" render={props => <Login{...props} />} />
                    <Route exact path="/register" render={props => <Register{...props} />} />
                </ApolloProvider>
           <LibraryHome/>
            
            
         </Layout>   
        </HashRouter>
        <Footer/>
           
        </div>,
    app);
    