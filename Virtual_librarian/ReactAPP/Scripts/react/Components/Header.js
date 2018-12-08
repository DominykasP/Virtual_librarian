import React from "react";
import Title from "./Header/LogedInPage/Title";

export default class Header extends React.Component {

    render() {
        return (
            <div>
            <Title title={this.props.title} />
                <input />
                
                </div>
        );
    }
}