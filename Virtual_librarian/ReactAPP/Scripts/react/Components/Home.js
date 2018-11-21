import React from "react";
import { StickyContainer, Sticky } from 'react-sticky';
import Background from './images/sharon-mccutcheon-532782-unsplash.png';
import "./margins.css"

import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button,
} from 'reactstrap';
var sectionStyle = {
    flex: 1,
    resizeMode: 'cover',
    margin: "-20rem -20rem 10rem 10rem",
    height: 667,
    width: 1000,
    backgroundImage: `url(${Background})`
};
export default class Home extends React.Component {

    render() {

        return (
            <div className="outside">
            <section style={sectionStyle}>
            
                </section>
                </div>
        );
    }
}
Home.id = "app";