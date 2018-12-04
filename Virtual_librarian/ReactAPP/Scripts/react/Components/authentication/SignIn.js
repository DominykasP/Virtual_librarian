
import React, { Component, useCallback } from "react";
import "../LogedInPage/margins.css"
import { getPersonByLoginData} from "./Utils";
import PropTypes from 'prop-types';
import classNames from 'classnames';
//import { Button, Radio, Icon } from 'antd';
import { Link } from "react-router-dom";
import 'antd/dist/antd.css';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import Background from '../LogedInPage/images/virtual-librarian-main-page.png';
//import { getPersonByLoginData } from "./Utils";
import axios from 'axios';
import { render } from "react-dom";
import {
    Container, Col, Form,
    FormGroup, Label, Input,
   /* Button,*/
} from 'reactstrap';
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
            
        }
        this.login = this.login.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.getPerson = this.getPerson.bind(this);
    }
    getPerson = async() => {
        let xmls =
            '<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">\
         <soap12:Body>\
            <GetPersonByNameSurnamePassword xmlns="api/PersonService">\
                <name>' + "E" + '</name>\
                <surname>' + "P" + '</surname>\
                <password>' + "s" + '</password>\
            </GetPersonByNameSurnamePassword>\
        </soap12:Body >\
        </soap12:Envelope >';


         axios.post('http://localhost:52312/PersonService.asmx?wsdl',
            xmls,
            {
                headers:
                {
                    'Content-Type': 'text/xml',
                    SOAPAction: "api/PersonService/GetPersonByNameSurnamePassword"
                }
            }).then(function (response) {
                console.log(response.data);
               /* var doc = new DOMParser().parseFromString(response, 'text/xml');
                var valueXML = doc.getElementsByTagName('return');
                var temps = valueXML[0].children;
                var nortifications = [];
                for (var i = 0; i < temps.length; i++) {
                    var temp = temps[i].children;
                    var obj = {};
                    for (var j = 0; j < temp.length; j++) {
                        var property = temp[j];

                        obj[property.localName] = property.innerHTML;
                    }
                    console.log(JSON.stringify(obj));
                    nortifications.push(obj);
                }*/
                


                return response.data;
                /* atsakymas yra res.data */

            }).catch(err => {
                console.log("unable to load");
            });
}
  login = async() => {

      var get = await getPersonByLoginData(this.state.username, this.state.surname, this.state.password, callback)
          .then((response) => {
              //console.log(response);
              callback = response;
              return callback;
          })
          ; 
      console.log("something");
      console.log(callback.data);
      var doc = new DOMParser().parseFromString(callback.data, 'text/xml');
      var valueXML = doc.getElementsByTagName('GetPersonByNameSurnamePasswordResult');
      var temps = valueXML[0].children;
      var nortifications = [];
      for (var i = 0; i < temps.length; i++) {
          var temp = temps[i].children;
          var obj = {};
          for (var j = 0; j < temp.length; j++) {
              var property = temp[j];

              obj[property.localName] = property.innerHTML;
          }
          
          console.log(JSON.stringify(obj));

          nortifications.push(obj);
      }
      console.log(valueXML[0].children);
      <h3>callback</h3>
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
                    <img className="picture" src={Background} alt="Background" />
                    <Container>
                        <div background-size='cover' className="homepage">
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
                                    style={{  marginTop: 20, }}

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
                                    style={{ marginRight: 120,  marginTop: 50,}}

                                />
                                <TextField
                                    id="standard-password-input"
                                    style={{ marginTop: 120, marginTop:50, }}
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

                            <Link to="/library/home">
                            <Button size="large" onClick={this.login} variant="contained" color="primary" className={classes.button}>SignIn</Button>
                            </Link>

                            <Link to="/register">
                                <Button color="primary">Register</Button>
                            </Link>
                        </div>
                    </Container>
                    
                </div>
            );
        }
}


export default withStyles(styles)(SignIn);
SignIn.id = "app";