
import React, { Component } from "react";
import "../LogedInPage/margins.css"
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

class SignIn extends React.Component {
    /*Button*/
    const
    state = {
        size: 'large',
    };
    /*textboxes state*/
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: ''
        }
        this.login = this.login.bind(this);
        this.onChange = this.handleChange.bind(this);
    }
    login() {
        console.log("Login function");
    }
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
                                    label="Username"
                                    onChange={this.handleChange('username')}
                                    value={this.state.username}
                                    InputProps={{
                                        classes: {
                                            input: classes.resizeFont,
                                        },
                                    }}
                                    className={classes.textField}
                                    margin="dense"
                                    style={{ marginRight: -120, marginTop: 20, fontSize: '<50>', }}

                                />
                                <TextField
                                    id="standard-password-input"
                                    style={{ marginTop: 80, fontSize: '80em', }}
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

                            {/*<Link to="/library/home">*/}
                            <Button size="large" onClick={this.login} variant="contained" color="primary" className={classes.button}>SignIn</Button>
                            {/*</Link>*/}

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