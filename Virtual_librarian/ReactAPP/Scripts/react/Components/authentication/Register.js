import React, { Component } from "react";
import "../LogedInPage/margins.css";
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
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

class Register extends React.Component{
    state = {
        username: '',
        surename: '',
        email: '',
        password: '',
        repeatpassword: '',
    };
    handleChange = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };
    onSubmit = async () => {
        const response = await this.props.mutate({
            variables: this.state,
        });
        console.log(response);
    };
    render() {
        const { classes } = this.props;
       
        return (
            <div>
                <img className="picture" src={Background} alt="Background" />
                    <div background-size='cover' className="homepage">
                    <h2>Sign In</h2>
                    <form className={classes.container} noValidate autoComplete="off">
                        <TextField
                            id="username"
                            label="Username"
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
                            label="Surename"
                            className={classes.textField}
                            value={this.state.surename}
                            onChange={this.handleChange('surename')}
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