
import React, { Component } from "react";
import "../LogedInPage/margins.css"
import PropTypes from 'prop-types';
import classNames from 'classnames';
//import { Button, Radio, Icon } from 'antd';
import { Link } from "react-router-dom";
import 'antd/dist/antd.css';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button,
} from 'reactstrap';
/*Text box*/
/*const styles = theme => ({
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
});*/

export default class SignIn extends React.Component{
    /*Button*/
    state = {
        size: 'large',
    };
    /*textboxes state*/
    constructor(props) {
        super(props);

        this.state = {
            name: "Cat in the Hat",
            age: "",
            multiline: "Controlled",
            currency: "EUR", };
    }
    

    
    render() {
        const size = this.state.size;
        //const classes = styles;
        return (
           
           

            <Container>
                <div className="homepage">
                    <h2>Sign In</h2>
                    <form noValidate autoComplete="off">
                        <TextField
                            id="Username"
                            label="Username"
                          
                            
                            margin="dense"
                        style={{ marginRight:-120,marginTop:20, fontSize: '<50>', }}
                        />
                    <TextField
                            id="standard-password-input"
                            
                            style={{ marginTop:80,  fontSize: '80em', }}
                        label="Password"
                        type="password"
                        title={this.state.name}
                            
                margin="normal"
                            autoComplete="current-password"

                        />
                        
                       
                        
                    </form>
                    <Link to="/library/home">
                        <Button color="primary">SignIn</Button>
                        </Link>
                    <Link to="/register">
                        <Button color="primary">Register</Button>
                    </Link>
                </div>
                </Container>
              
               
           
        );
    }
}
SignIn.id = "app";