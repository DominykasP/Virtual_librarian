import React from "react";
import { Link } from 'react-router-dom'
import Header from "./Header";
import Footer from "./Footer";
export default class LayoutMy extends React.Component {
    constructor() {
        super();
        this.state = {name: "zmogau"};
    }
    
    render() {
       // const title = "get react";
       // setTimeout(() => {
      //      this.setState({ name: "Bob" });
        //},3000)
        return (
            <div>
                
                {this.props.children}
                <Link to="/"></Link>
                <Link to="archives"></Link>
                <Link to="settings"></Link>
                
            </div>
                     
        );
    }
}
LayoutMy.id = "app";