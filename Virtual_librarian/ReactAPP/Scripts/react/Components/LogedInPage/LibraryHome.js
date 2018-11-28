import React from "react"
import "./margins.css"
import { Route } from "react-router";
import Archives from "./Archives";
import Featured from "./Featured";
import Layout from "./Layout";
import Settings from "./Settings";
import Home from "./LoginHome";
import Devices from "./Devices";


import Library from "./LibraryObjects/Library";
import MyBooks from "./LibraryObjects/LibraryBooks";
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import Contacts from "./Contacts";
import Footer from "./Footer/Footer";

export default class LibraryHome extends React.Component {

    render() {
        return (

            <div className="nomargins">
                <Route  path="/library" render={({ location, history }) => (
                    <React.Fragment>
                        <SideNav
                            onSelect={(selected) => {
                                const to = '/' + selected;
                                if (location.pathname !== to) {
                                    history.push(to);
                                }
                            }}>
                            <SideNav.Toggle />
                            <SideNav.Nav defaultSelected="/">
                                <NavItem eventKey="library/home">
                                    <NavIcon>
                                        <i className="fa fa-fw fa-home" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Home
                        </NavText>
                                </NavItem>
                                
                                <NavItem eventKey="library/devices">
                                    <NavIcon>
                                        <i className="fa fa-laptop" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Devices
                        </NavText>
                                </NavItem>
                                <NavItem eventKey="library/library">
                                    <NavIcon>
                                        <i className="fas fa-book-reader" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Library
                        </NavText>
                                </NavItem>
                                <NavItem eventKey="library/mybooks">
                                    <NavIcon>
                                        <i className="fa fa-book" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        My Books
                        </NavText>
                                </NavItem>
                                <NavItem eventKey="library/contacts">
                                    <NavIcon>
                                        <i className="fas fa-address-book" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Contacts
                        </NavText>
                                </NavItem>
                                <NavItem eventKey="login">
                                    <NavIcon>
                                        <i className="fas fa-sign-out-alt" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Sign Out
                        </NavText>
                                </NavItem>
                            </SideNav.Nav>
                        </SideNav>
                        <main>
                            <Route exact={true} path="/welcome" render={() => (
                                <h1>Welcome</h1>
                            )} />
                            
                            <Route exact={true} path="/library/home" component={Home} />
                            
                            <Route path="/library/devices" component={props => <Devices />} />
                            <Route exact={true} path="/library/library" component={Library} />
                            <Route path="/library/mybooks" component={MyBooks} />
                            <Route path="/library/contacts" component={Contacts} />
                            <Route exact={true} path="login"/>
                        </main>
                    </React.Fragment>
                )}
                />
            </div>


        );
    }
}
Settings.id = "app";