import React from "react";
import { render } from "react-dom";
import { makeData, getBooksFromServer, Logo, Tips } from "./Utils";

// Import React Table
import ReactTable from "react-table";
import "react-table/react-table.css";
import "./LibraryStyling.css"

export default class Library extends React.Component {
    constructor() {
        super();
        this.state = {
            booksInXML: getBooksFromServer(function (response) {
                console.log(response);
            }),
            data: makeData()
        };
        //this.handleClick();

        //this.handleClick = this.handleClick.bind(this)
    }

    render() {
        return (
            <div className='outside'>
                <button className='button'>
                    Click Me
                </button>
                <p>{console.log(this.state.booksInXML)}</p>
                
            </div>
        )
        
        /*
         * <p>{this.state.booksInXML[0].children[0].name}</p>
         * 
        const { data } = this.state;

        console.log(data);

        return (
            <div className="outside">
                <ReactTable
                    data={data}
                    columns={[
                        {
                            Header: "Name",
                            columns: [
                                {
                                    Header: "First Name",
                                    accessor: "firstName"
                                },
                                {
                                    Header: "Last Name",
                                    id: "lastName",
                                    accessor: d => d.lastName
                                }
                            ]
                        },
                        {
                            Header: "Info",
                            columns: [
                                {
                                    Header: "Age",
                                    accessor: "age"
                                },
                                {
                                    Header: "Status",
                                    accessor: "status"
                                }
                            ]
                        },
                        {
                            Header: 'Stats',
                            columns: [
                                {
                                    Header: "Visits",
                                    accessor: "visits"
                                }
                            ]
                        }
                    ]}
                    defaultPageSize={10}
                    className="-striped -highlight"
                />
                <br />
                <Tips />
                <Logo />
            </div>

        );
        */
    }
}
