import React from "react";
import ReactDOM from "react-dom";
import "./Components/margins.css"
import {  Route} from "react-router";
import { HashRouter } from 'react-router-dom';
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import '@trendmicro/react-sidenav/dist/react-sidenav.css';
// Be sure to include styles at some point, probably during your bootstraping

import "./Components/margins.css";
//import Bootstrap from "./vendor/bootstrap-without-jquery";
import Archives from "./Components/Archives";
import Featured from "./Components/Featured";
import Layout from "./Components/Layout";
import Settings from "./Components/Settings";
import Home from "./Components/Home";
import Devices from "./Components/Devices";
import Register from "./Components/authentication/Register";
import Login from "./Components/authentication/SignIn";
import Library from "./Components/LibraryObjects/Library";
import MyBooks from "./Components/LibraryObjects/LibraryBooks";
import Contacts from "./Components/Contacts";
import Footer from "./Components/Footer/Footer";

const app = document.getElementById('app');

ReactDOM.render(
    <div >
        
        <HashRouter basename="/">
        <Layout>
        
                {/*<Route path="/" exact component={Featured}></Route>
            <Route path="/archives" component={Archives}></Route>
            <Route path="/settings" component={Settings}></Route>*/}
            <div className="nomargins">
                    <Route render={({ location, history }) => (
                <React.Fragment>
                    <SideNav
                        onSelect={(selected) => {
                            const to = '' + selected;
                            if (location.pathname !== to) {
                                history.push(to);
                            }
                        }}>
                        <SideNav.Toggle />
                        <SideNav.Nav defaultSelected="home">
                            <NavItem eventKey="/home">
                                <NavIcon>
                                    <i className="fa fa-fw fa-home" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Home
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="/register">
                                <NavIcon>
                                    <i className="fas fa-user-plus" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Register
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="/login">
                                <NavIcon>
                                    <i className="fa fa-user" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Login
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="/devices">
                                <NavIcon>
                                    <i className="fa fa-laptop" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Devices
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="/library">
                                <NavIcon>
                                    <i className="fas fa-book-reader" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Library
                        </NavText>
                            </NavItem>
                                <NavItem eventKey="/mybooks">
                                    <NavIcon>
                                    <i className="fa fa-book" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        My Books
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="/contacts">
                                <NavIcon>
                                    <i className="fas fa-address-book" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                   Contacts
                        </NavText>
                            </NavItem>
                        </SideNav.Nav>
                    </SideNav>
                    <main>
                        <Route exact={true} path="/welcome" render={() => (
                            <h1>Welcome</h1>
                            )}/>
                                <Route exact={true} path="/" component={Home} />
                                <Route exact={true} path="/home" component={Home} />
                        <Route path="/register" component={Register} />
                        <Route path="/login" component={Login} />
                            <Route path="/devices" component={props => <Devices />} />
                            <Route path="/library" component={Library} />
                        <Route path="/mybooks" component={MyBooks} />
                        <Route path="/contacts" component={Contacts} />
                    </main>
                </React.Fragment>
            )}
                    />
                    </div>
            
            
         </Layout>   
        </HashRouter>
        <Footer/>
           
        </div>,
    app);
    