
import React, { Component } from 'react';
import "./_sticky-footer.css";
import DatePicker from 'react-date-picker';


export default class Footer extends React.Component {
    constructor() {
        super();

        var today = new Date(),
            date = today.getFullYear() ;

        this.state = {
            date: date
        };
    }
    render() {
        var today = new Date();
        return (
            <div className="Site-content:after">
                <hr />
                <div className="backgroundCol">
                    <footer >
                        <h1 >@{this.state.date} - Virtual Librarian</h1>
                </footer>
                    </div>
            </div>
        );
    }
}