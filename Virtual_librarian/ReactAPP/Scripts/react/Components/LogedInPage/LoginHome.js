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
            <div>
                
                <ParallaxBanner
                    className="homepage"
                    layers={[
                        {
                            image: url('./images/BlueLibraryAuthenticationBackground.png'),
                            amount: 0.1,
                            slowerScrollRate: false,
                        },
                        {
                            image: url('./images/BlueLibraryAuthenticationBackground.png'),
                            amount: 0.2,
                            slowerScrollRate: false,
                        },
                    ]}
                    style={{
                        height: '500px',
                    }}
                >
                    <h1>Banner Children</h1>
                </ParallaxBanner>
               
            </div>
        );
    }
}