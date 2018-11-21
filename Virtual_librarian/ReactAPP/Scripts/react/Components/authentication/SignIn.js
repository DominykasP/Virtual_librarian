
import React, { Component } from "react";
import "./AuthenticationStyling.css"
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
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
        fontSize: 50,
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

export default class SignIn extends React.Component{
    constructor(props) {
        super(props);

        this.state = {
            name: "Cat in the Hat",
            age: "",
            multiline: "Controlled",
            currency: "EUR", };
    }
    

    
    render() {
        const  classes  = styles;
        return (
            <div className="outside">
               
                <Container>
                    <h2>Sign In</h2>
                    <form noValidate autoComplete="off">
                        <TextField
                            id="Username"
                            label="Username"
                            className={classNames(classes.textField, classes.dense)}
                            margin="dense"
                            style={{ marginLeft: 8, marginRight: 500, marginTop: 8, marginBottom: 8, width: 300, fontSize: '30em', }}
                        />
                    <TextField
                            id="standard-password-input"
                            className={classes.textField}
                            style={{ marginLeft: 8, marginRight: 500, marginTop: 8, marginBottom: 8, width: 300, fontSize: '30em', }}
                        label="Password"
                        type="password"
                        title={this.state.name}
                            
                margin="normal"
                autoComplete="current-password"
            />
                       
                        
                    </form>
                    <Button width="100px" color="primary">Submit</Button>
                   </Container>
               
            </div>
        );
    }
}
SignIn.id = "app";