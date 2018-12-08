import React, { Component } from "react";
import { Link } from "react-router-dom";

import { getPersonByLoginData, addPersonByRegisterData } from "./Utils";

import "../LogedInPage/margins.css";


import { withStyles, MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import PropTypes from 'prop-types';
import classNames from 'classnames';

import purple from '@material-ui/core/colors/purple';
import green from '@material-ui/core/colors/green';
import { DateFormatInput} from 'material-ui-next-pickers'
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';


import 'babel-polyfill';

import {
    Container, Col, Form,
    FormGroup, Label, Input,
    
} from 'reactstrap';
const theme = createMuiTheme({
    palette: {
        primary: green,
    },
    typography: {
        useNextVariants: true,
    },
});
const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        marginTop: '1px',
    },
    margin: {
        margin: theme.spacing.unit,
    },
    textField: {
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        width: 200,
    },
    cssRoot: {
        color: theme.palette.getContrastText(purple[500]),
        backgroundColor: green[500],
        '&:hover': {
            backgroundColor: green[700],
        },
    },
    dense: {
        marginTop: 19,
    },
    menu: {
        width: 200,
    },
    resizeFont: {
        fontSize: 12,
    },
});
/*const year = new Date().getFullYear();
const items = [];
for (let i = 0; i < 100; i++) {
    items.push(<MenuItem value={year - 100} key={i} primaryText={`${i}`} />);
}*/
var callback;
var useCallback;
var ID = 10;
class Register extends React.Component{
    state = {
        username: '',
        surname: '',
        email: '',
        password: '',
        repeatpassword: '',
        datenew: '',
        exists: 0,
        phonenumber: '',
    };
    handleChange = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };
    onChangeDate = (date) => {
        console.log('Date: ', date)
        this.setState({ date })
        var date = new Date(date)
        var finaldate = date.getFullYear() + '-' + (date.getMonth() + 1) + '-'
        if (date.getDate() < 10) {
            finaldate = finaldate + '0' + date.getDate()
        }
        else {
            finaldate = finaldate +  date.getDate()
        }
        this.state.datenew = finaldate
        console.log("-" + this.state.datenew + "-")
    } 
    
    onSubmit = async () => {
        var get = await getPersonByLoginData(this.state.username, this.state.surname, this.state.password, callback)
            .then((response) => {
                //console.log(response);
                callback = response;
                return callback;
            });

        var XMLParser = require('react-xml-parser');

        var InXML = new XMLParser().parseFromString(callback.data);

        var UserinXML = InXML.getElementsByTagName('GetPersonByNameSurnamePasswordResponse');
        console.log(UserinXML);
        this.state.exists = UserinXML[0].children.length;
        console.log(this.state.exists);
        if (this.state.exists == 0) {
            var add = await addPersonByRegisterData(ID, this.state.username, this.state.surname, this.state.password, this.state.datenew, this.state.phonenumber, this.state.email, useCallback).then((response) => {
                //console.log(response);
                useCallback = response;
                return useCallback;
            });
        }
        else {

        }
        console.log(useCallback);
    };
    render() {
        const { classes } = this.props;
        const { date } = this.state;
        return (
            
            <div background-size='cover' className="hero">

                <Container>
                    <div style={{ marginTop: 50 }} className="homepage">
                    <h2>Sign Up</h2>
                    <form  className={classes.container} noValidate >
                       
                        <TextField
                            id="username"
                            label="Name"
                            className={classes.textField}
                            value={this.state.username}
                            onChange={this.handleChange('username')}
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}
                        />
                       
                        <TextField
                            id="surename"
                            label="Surname"
                            className={classes.textField}
                            value={this.state.surname}
                            onChange={this.handleChange('surname')}
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100,  marginTop: 30,marginBottom:30 }}
                        />
                            <div style={{ marginLeft: 92 }}>
                                <MuiThemeProvider>
                                <DateFormatInput
                                    label="Birth Date"
                                    min={new Date('1950-1-1, 6:37 pm')}
                                    className={classes.textField}
                                    name='date-input'
                                    dateFormat="MMMM d, yyyy"
                                    margin = "normal"
                                    value={date}
                                    style={{marginLeft: 50000, marginTop: 100, }}
                                    onChange={this.onChangeDate}
                                    />
                                    </MuiThemeProvider>
                       </div>
                        <TextField
                            id="email"
                            label="Email"
                            className={classes.textField}
                            value={this.state.email}
                            onChange={this.handleChange('email')}
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}
                        />
                        <TextField
                            id="email"
                            label="Phone Number"
                            className={classes.textField}
                            value={this.state.phonenumber}
                            onChange={this.handleChange('phonenumber')}
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}
                        />
                        <TextField
                            id="password"
                            label="Password"
                            className={classes.textField}
                            value={this.state.password}
                            onChange={this.handleChange('password')}
                            type="password"
                            autoComplete="current-password"
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}
                        />
                        <TextField
                            id="repeatpassword"
                            label="Repeat Password"
                            className={classes.textField}
                            value={this.state.repeatpassword}
                            onChange={this.handleChange('repeatpassword')}
                            type="password"
                            autoComplete="repeat-password"
                            margin="normal"
                            InputProps={{
                                classes: {
                                    input: classes.resizeFont,
                                },
                            }}
                                style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}
                            />
                           
                    </form>
                        <Link to="/login">
                            <Button
                                size="large"
                                variant="contained"
                                color="primary"
                                className={classNames(classes.margin, classes.cssRoot)}
                            >
                                Register
                                </Button>
                        </Link>  
                    <Link to="/login">
                        <Button onClick={() => this.onSubmit()} color="primary">Cancel</Button>
                        </Link>  
                        
                    </div>
                    </Container>
                    </div>
           
        );
    }

}




export default withStyles(styles)(Register);

Register.id = "app";