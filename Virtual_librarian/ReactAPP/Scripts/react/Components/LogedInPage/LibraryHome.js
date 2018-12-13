import React from "react"
import "./margins.css"
import { Route } from "react-router-dom";
import Archives from "./Archives";
import Featured from "./Featured";
import Layout from "./Layout";
import Settings from "./Settings";
import Home from "./HomePage/LoginHome";
import Devices from "./Devices";


import Library from "./LibraryObjects/Library";
import MyBooks from "./LibraryObjects/LibraryBooks";
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import Contacts from "./Contacts";
import Footer from "./Footer/Footer";

import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import AppBarClass from './AppBar'

{/*var RightSideStuff = React.createClass({
    render() {
        return (
            <span>
                <FlatButton label="Foo" style={styles.items} />
                <FlatButton label="Bar" style={styles.items} />
                <Toolbar
                    targetOrigin={{ horizontal: 'right', vertical: 'top' }}
                    anchorOrigin={{ horizontal: 'right', vertical: 'top' }}>
                    <IconButton align='center' className={classes.menuButton} color="primary" aria-label="Menu">
                        <MenuIcon />
                    </IconButton>
                    <Typography align='center' color="inherit" className={classes.grow}>
                        <h1 align='center'> Virtual Library</h1>

                    </Typography>
                     <Button align='center' color="inherit">Login</Button> 

                </Toolbar>
               
            </span>
        );

    }
});*/}

const styles = theme =>{
    root: {
        flexGrow: 1;
        
        
    };
    grow: {
        flexGrow: 1;
        textAlign: 'center';
    };
    menuButton: {
        marginLeft: -12;
        marginRight: 20;
    };
};



 class LibraryHome extends React.Component {
   
    constructor(props) {
        super(props);
        this.state = {
            IDd: 'labas',
           expanded: false
        }
        //console.log(props.location.state.id)
        //console.log(this.props.location.state.id);
     }



    
    render() {
        const { classes } = this.props;

        //console.log(this.props.location.state.ID);
        return (
            
            <div className="nomargins">
               
                <div className = "sidebar">
                <Route path="/library" render={({ location, history }) => (
                    <div className={classes.root}>
                            <AppBar position="static">
                                <Toolbar >
                                    <IconButton  align='center' className={classes.menuButton} color="primary" aria-label="Menu">
                                        <MenuIcon />
                                    </IconButton>
                                    <Typography align='center' color="inherit" className={classes.grow}>
                                        <h1 align='center'> Virtual Library</h1>

                                        </Typography>
                                    {/*<Button align='center' color="inherit">Login</Button>*/}

                                </Toolbar>
                                
                            </AppBar>
                       
                        <React.Fragment >
                            
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
                                
                                        {/*<NavItem eventKey="library/devices">
                                    <NavIcon>
                                        <i className="fa fa-laptop" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Devices
                        </NavText>
                                </NavItem>*/}
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
                                    {/*<NavItem eventKey="library/contacts">
                                    <NavIcon>
                                        <i className="fas fa-address-book" style={{ fontSize: '1.75em' }} />
                                    </NavIcon>
                                    <NavText>
                                        Contacts
                        </NavText>
                                </NavItem>*/}
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
                            <Route exact={true} path="/library" render={() => (
                                <h1>Welcome </h1>
                            )} />
                            
                            <Route path="/library/home" component={Home} />                           
                            <Route path="/library/devices" component={props => <Devices />} />
                            <Route path="/library/library" component={Library} />
                            <Route path="/library/mybooks" component={MyBooks} />
                            <Route path="/library/contacts" component={Contacts} />
                            <Route path="login"/>
                        </main>
                            </React.Fragment>
                            <Footer />
                            </div>
                    
                )}
                    />
                    
                </div>
                
            </div>

        );
    }
}

LibraryHome.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(LibraryHome);

Settings.id = "app";

