import React, { Component } from "react";
import { getPersonByLoginData, addPersonByRegisterData} from "./Utils";
import "../LogedInPage/margins.css";
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { DateFormatInput, TimeFormatInput } from 'material-ui-next-pickers'
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import 'antd/dist/antd.css';
import Background from '../LogedInPage/images/virtual-librarian-main-page.png';
import gql from 'graphql-tag';
import 'babel-polyfill';
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    
} from 'reactstrap';

const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        marginTop: '1px',
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
            <div>
                <img className="picture" src={Background} alt="Background" />
                    <div background-size='cover' className="homepage">
                    <h2>Sign Up</h2>
                    <form margin-top={"-200px"} className={classes.container} noValidate >
                       
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
                            style={{ marginRight: 120, marginTop: 30, }}
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
                            style={{ marginRight: 120, marginTop: 30, }}
                        />
                        <MuiThemeProvider>
                            <DateFormatInput label="Birth Date" min={new Date('1950-1-1, 6:37 pm')} name='date-input' dateFormat="MMMM d, yyyy" value={date} onChange={this.onChangeDate} />
                        </MuiThemeProvider>
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
                            style={{ marginRight: 120, marginTop: 30, }}
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
                            style={{ marginRight: 120, marginTop: 30, }}
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
                            style={{ marginRight: 120, marginTop: 30, }}
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
                            style={{ marginRight: 120, marginTop: 30, }}
                            />
                           
                    </form>
                    <Link to="/login">
                        <Button  onClick={() => this.onSubmit()} color="primary">Submit</Button>
                    </Link>  
                    <Link to="/login">
                        <Button onClick={() => this.onSubmit()} color="primary">Cancel</Button>
                    </Link>  
                    </div>
            </div>
        );
    }

}




export default withStyles(styles)(Register);

Register.id = "app";