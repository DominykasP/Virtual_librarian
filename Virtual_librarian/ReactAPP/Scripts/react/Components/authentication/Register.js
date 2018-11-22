import React, { Component } from "react";
import "../LogedInPage/margins.css";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import { Link } from "react-router-dom";
import Background from '../LogedInPage/images/virtual-librarian-main-page.png';
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

export default class Register extends React.Component{
    constructor(props) {
        super(props);

        this.state = {
            name: "Cat in the Hat",
            email: "",
            password: "",
            repeatpassword: "",
        };
    }
    render() {
        const classes = styles;
        return (
            <div>
            <img className="picture" src={Background} alt="Background" />
            <Container>
                <div background-size = 'cover' className="homepage">
                    <h2>Sign Up</h2>
                    <form  noValidate autoComplete="off">
                    <TextField
                        id="registerEmail"
                        label="Email"
                            style={{ marginRight: -120, marginTop: 8,   fontSize: '30em', }}
                       
                        margin="dense"
                        
                    />
                    <TextField
                        id="registerUsername"
                        label="Username"
                        
                            style={{ marginRight: -120,  marginTop: 68, fontSize: '30em', }}
                        margin="dense"
                       
                    />
                   
                    <TextField
                        id="registerPassword"
                        
                            style={{ marginRight: -120, marginTop: 128,  fontSize: '30em', }}
                        label="Password"
                        type="password"
                        title={this.state.password}

                       
                        autoComplete="current-password"
                    />
                   
                    <TextField
                        id="register-repeat-password"
                       
                            style={{ marginTop: 188,  fontSize: '30em', }}
                    label="Repeat password"
                    type="password"
                        title={this.state.name}

                        margin="normal"
                        autoComplete="current-password"
                    />
                       
                    </form>
                    <div >
                            <Button width="100px" color="primary"  >Register</Button>
                            <Link to="/">Cancel</Link>
                    </div>
                </div>
                </Container>
         </div>

        );
    }
}
Register.id = "app";