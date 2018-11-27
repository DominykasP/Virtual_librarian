import React, { Component } from "react";
import "../LogedInPage/margins.css";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import { Link } from "react-router-dom";
import Background from '../LogedInPage/images/virtual-librarian-main-page.png';
import gql from 'graphql-tag';
import 'babel-polyfill';
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button,
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
});

class Register extends React.Component{
    state = {
        username: 'Cat in the Hat',
        email: '',
        password: 'Controlled',
        repeatpassword: 'EUR',
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
                        />
                        <TextField
                            id="email"
                            label="Email"
                            className={classes.textField}
                            value={this.state.email}
                            onChange={this.handleChange('email')}
                            margin="normal"
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
                        />
                    </form>
                    <Button onClick={() => this.onSubmit()} type = "primary">Submit</Button>
                    </div>
            </div>
        );
    }

}

const mutation = gql`
mutation($username: String!, $email: String!, $password: String!, $repeatpassword: String!) {
	register(username: $username, email: $email, password: $password, repeatpassword: $repeatpassword) {
	  id
	} 
}
`;



export default withStyles(mutation, styles)(Register);

Register.id = "app";