
import React, { Component, useCallback } from "react";
import "../LogedInPage/margins.css";
import { getPersonByLoginData} from "./Utils";
//import { Button, Radio, Icon } from 'antd';
import ReactDOM from "react-dom";
import { Link, Route } from "react-router-dom";
import 'antd/dist/antd.css';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

import { Redirect } from 'react-router-dom'
import { withRouter } from "react-router";
import Background from '../LogedInPage/images/virtual-librarian-main-page.png';
import LibraryHome from "../LogedInPage/LibraryHome"
//import { getPersonByLoginData } from "./Utils";
import axios from 'axios';
import { render } from "react-dom";
import {Container} from 'reactstrap';
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
       fontSize: 50,
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
        
        
    }
    
  login = async() => { var get = await getPersonByLoginData(this.state.username, this.state.surname, this.state.password, callback).then((response) => {
             
              callback = response;
              return callback;
          }); 
   
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
          let path = `/library/home`;
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
   

        render() {
            const { classes } = this.props;
            const size = this.state.size;

            return (

                <div>
                   
                    <Container>
                        <div className="homepage">
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
                                    margin="dense"
                                    style={{ marginTop: 20, }}

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
                                    margin="dense"
                                    style={{ marginRight: 120, marginTop: 50, }}

                                />
                                <TextField
                                    id="standard-password-input"
                                    style={{ marginTop: 120, marginTop: 50, }}
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
                                <Button color="primary">Register</Button>
                            </Link>
                                
                            
                        </div>
                    </Container>
                    
                </div>
            );
        }
}
SignIn = withStyles(styles)(SignIn);
export default withRouter(SignIn);

SignIn.id = "app";