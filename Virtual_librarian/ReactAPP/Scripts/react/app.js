import React from "react";
import ReactDOM from "react-dom";
import "./Components/LogedInPage/margins.css"
import {  Route} from "react-router";
import { HashRouter } from 'react-router-dom';
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import '@trendmicro/react-sidenav/dist/react-sidenav.css';
// Be sure to include styles at some point, probably during your bootstraping


//import Bootstrap from "./vendor/bootstrap-without-jquery";
import Home from "./Components/Home";
import Layout from "./Components/LogedInPage/Layout";
import Footer from "./Components/LogedInPage/Footer/Footer";
import Register from "./Components/authentication/Register";
import LibraryHome from "./Components/LogedInPage/LibraryHome";

const app = document.getElementById('app');

ReactDOM.render(
    <div >
        
        <HashRouter basename="/">
        <Layout>
        
                <Route path="/" exact component={Home}></Route>
                <Route path="/home" exact component={Home}></Route>
                <Route path="/register" exact component={Register}></Route>
           <LibraryHome/>
            
            
         </Layout>   
        </HashRouter>
        <Footer/>
           
        </div>,
    app);
    