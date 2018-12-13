import React from "react";
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';

export default class AppBarel extends React.Component {
    render() {
        return (
            <span>
             
                <Toolbar
                    /*targetOrigin={{ horizontal: 'right', vertical: 'top' }}
                    anchorOrigin={{ horizontal: 'right', vertical: 'top' }}*/>
                    <IconButton align='center' className={classes.menuButton} color="primary" aria-label="Menu">
                        <MenuIcon />
                    </IconButton>
                    <Typography align='center' color="inherit" className={classes.grow}>
                        <h1 align='center'> Virtual Library</h1>

                    </Typography>
                    <Button align='center' color="inherit">Login</Button>

                </Toolbar>

            </span>
        );

    }
};

