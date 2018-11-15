import React from "react";
import ReactDOM from "react-dom";
import {  Route} from "react-router";
import { HashRouter } from 'react-router-dom';
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import '@trendmicro/react-sidenav/dist/react-sidenav.css';
// Be sure to include styles at some point, probably during your bootstraping


//import Bootstrap from "./vendor/bootstrap-without-jquery";
import Archives from "./Components/Archives";
import Featured from "./Components/Featured";
import Layout from "./Components/Layout";
import Settings from "./Components/Settings";
import Home from "./Components/Home";
import Devices from "./Components/Devices";
import Register from "./Components/Register";
import Login from "./Components/SignIn";


const app = document.getElementById('app');

ReactDOM.render(

    <HashRouter>
        <Layout>
        
            <Route path="/" exact component={Featured}></Route>
            <Route path="/archives" component={Archives}></Route>
            <Route path="/settings" component={Settings}></Route>
            
            <Route render={({ location, history }) => (
                <React.Fragment>
                    <SideNav
                        onSelect={(selected) => {
                            const to = '/' + selected;
                            if (location.pathname !== to) {
                                history.push(to);
                            }
                        }}
                    >
                        <SideNav.Toggle />
                        <SideNav.Nav defaultSelected="home">
                            <NavItem eventKey="home">
                                <NavIcon>
                                    <i className="fa fa-fw fa-home" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Home
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="register">
                                <NavIcon>
                                    <i className="fa fa-user-plus" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Register
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="login">
                                <NavIcon>
                                    <i className="fa fa-sign-in" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Login
                        </NavText>
                            </NavItem>
                            <NavItem eventKey="devices">
                                <NavIcon>
                                    <i className="fa fa-laptop" style={{ fontSize: '1.75em' }} />
                                </NavIcon>
                                <NavText>
                                    Devices
                        </NavText>
                            </NavItem>
                        </SideNav.Nav>
                    </SideNav>
                    <main>
                        <Route exact={true} path="/" render={() => (
                            <h1>Welcome</h1>
                            )}/>
                        <Route path="/home" component={Home} />
                        <Route path="/register" component={Register} />
                        <Route path="/login" component={Login} />
                        <Route path="/devices" component={props => <Devices />} />
                    </main>
                </React.Fragment>
            )}
            />
            
            
         </Layout>   
    </HashRouter>,
    app);
    