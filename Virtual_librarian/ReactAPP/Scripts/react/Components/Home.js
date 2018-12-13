import React from "react";
import {Link} from "react-router-dom"
import { Button } from 'antd';
import 'antd/dist/antd.css';
import { StickyContainer, Sticky } from 'react-sticky';
import Background from './LogedInPage/images/virtual-librarian-main-page.png';
import "./LogedInPage/margins.css";



import LogIn from "./authentication/SignIn";


import {
    Container, Col, Form,
    FormGroup, Label, Input,
 
} from 'reactstrap';
var sectionStyle = {
    
    marginTop: "-60px" ,
    width: "1500px",
    height: "879px",
    backgroundImage: `url(${Background})`
};
export default class Home extends React.Component {

    render() {

        return (
            <div>
                <div>
                    <img className="picture" src={Background} alt="Background" />
                    <div>   
                    
                        <div className="LinkColor">
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
Home.id = "app";