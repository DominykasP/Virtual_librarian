
import React, { Component, useCallback } from "react";
import { Link, Route, Redirect } from "react-router-dom";
import { withRouter } from "react-router";
import ReactDOM from "react-dom";
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    /* Button,*/
} from 'reactstrap';

import "../LogedInPage/margins.css"
import 'antd/dist/antd.css';

import { getPersonByLoginData} from "./Utils";

import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import purple from '@material-ui/core/colors/purple';
import green from '@material-ui/core/colors/green';

import LibraryHome from "../LogedInPage/LibraryHome"

/*Text box*/
const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    button: {
        margin: theme.spacing.unit,
    },
    input: {
        display: 'none',
    },
    margin: {
        margin: theme.spacing.unit,
    },
    cssRoot: {
        color: theme.palette.getContrastText(purple[500]),
        backgroundColor: green[500],
        '&:hover': {
            backgroundColor: green[700],
        },
    },
    textField: {
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        
        width: 200,
       
    },
    dense: {
        marginTop: 19,
    },
    menu: {
        width: 200,
    },
    resizeFont: {
        fontSize: 15,
        
    },
});
var callback;
class SignIn extends React.Component {
    /*Button*/
    
    
    /*textboxes state*/
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            surname: '',
            password: '',
            link: "/login",
            authenticated: 0,
            ID:0
        }
        this.login = this.login.bind(this);
        this.handleChange = this.handleChange.bind(this);
        
        this.protectedComponent = this.protectedComponent.bind(this);
    }
    
  login = async() => {

      var get = await getPersonByLoginData(this.state.username, this.state.surname, this.state.password, callback)
          .then((response) => {
              //console.log(response);
              callback = response;
              return callback;
          })
          ; 
   
      var XMLParser = require('react-xml-parser');
      
      var InXML = new XMLParser().parseFromString(callback.data);
      
      var UserinXML = InXML.getElementsByTagName('GetPersonByNameSurnamePasswordResponse');
      console.log(UserinXML);
      this.state.authenticated  = UserinXML[0].children.length;
      /*console.log(UserinXML[0].children[0].children[0].value);*/
      console.log("authenticated");
      console.log(this.state.authenticated);
     
     
      if (UserinXML[0].children.length == 0) {
         // console.log("yey");

      }
      if (this.state.authenticated > 0) {
          //console.log("yeyyey");
          //console.log(UserinXML[0].children[0].children[0].value);
          localStorage.setItem('userId', UserinXML[0].children[0].children[0].value);
          let path = `/library/library`;
          this.state.ID = UserinXML[0].children[0].children[0].value;
          this.props.history.push({
              pathname: path,
              search: '',
              state: { id: this.state.ID }
          });
        //  console.log("after"); 
      }
    };
    handleChange = name => event => {
        
        this.setState({
            [name]: event.target.value,
        });
        console.log(this.state);
    };
    protectedComponent = () => {
        if (this.state.authenticated == 0) {
            return <Redirect to='/login' />

        }
        else if (this.state.authenticated > 0)
            return <Redirect to='/library/home' />
    }

        render() {
            const { classes } = this.props;
            const size = this.state.size;

            return (
                <div className="hero">
                    <div className="homepage-Title">
                        Virtual Library
                        </div>
                    <div>
                    <Container>
                        <div  className="homepage">
                            <h2>Sign In</h2>

                            <form className={classes.container} noValidate autoComplete="off">
                                <TextField
                                    id="Username"
                                    label="Name"
                                    onChange={this.handleChange('username')}

                                    value={this.state.username}
                                    InputProps={{
                                        classes: {
                                            input: classes.resizeFont,
                                        },
                                    }}
                                    className={classes.textField}
                                    margin="normal"
                                    style={{ marginLeft:575, marginRight: 400}}

                                />
                                <TextField
                                    id="Surename"
                                    label="Surname"
                                    onChange={this.handleChange('surname')}

                                    value={this.state.surname}
                                    InputProps={{
                                        classes: {
                                            input: classes.resizeFont,
                                        },
                                    }}
                                    className={classes.textField}
                                    margin="normal"
                                    style={{ marginLeft: 575, marginRight: 600, marginTop: 30, }}

                                />
                                <TextField
                                    id="standard-password-input"
                                    style={{ marginLeft: 575, marginTop: 120, marginTop: 30, }}
                                    label="Password"
                                    type="password"
                                    title={this.state.name}
                                    value={this.state.password}
                                    onChange={this.handleChange('password')}

                                    InputProps={{
                                        classes: {
                                            input: classes.resizeFont,
                                        },
                                    }}
                                    className={classes.textField}
                                    margin="normal"
                                    autoComplete="current-password"
                                />
                            </form>


                            <Button size="large" onClick={this.login} variant="contained" color="primary" className={classes.button}>
                                SignIn
                                {/*<Redirect to={this.state.link}>
                                </Redirect>*/}
                                    </Button>
                            <Route path="/library" component={LibraryHome} something={this.state.ID} />

                            <Link to="/register">
                                <Button
                                    size="large" 
                                    variant="contained"
                                    color="primary"
                                    className={classNames(classes.margin, classes.cssRoot)}
                                >
                                    Register
                                </Button>
                            </Link>
                                
                            
                        </div>
                    </Container>
                    </div>
                </div>

            );
        }
}

SignIn.propTypes = {
    classes: PropTypes.object.isRequired,
};

SignIn = withStyles(styles)(SignIn);
export default withRouter(SignIn);

SignIn.id = "app";