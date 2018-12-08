import React from "react";
import { Parallax, ParallaxBanner ,Background } from 'react-scroll-parallax';
import "./margins.css";

import "./margins.css";
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button,
} from 'reactstrap';

export default class LoginHome extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            
            id:0
                
        }
        
        console.log(localStorage.getItem('userId'));
       
        /*console.log(this.props.location.state.id);*/
    }
   
    
    render() {

        return (
            <div className="homepage">
                
              <h1>Comming Soon</h1>
               
            </div>
        );
    }
}