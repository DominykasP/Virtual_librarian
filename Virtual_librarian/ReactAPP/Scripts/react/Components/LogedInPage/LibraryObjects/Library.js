import React from "react";
import { render } from "react-dom";
import { makeData, getBooksFromServer, Logo, Tips } from "./Utils";
import "xml-js";
// Import React Table
import ReactTable from "react-table";
import "react-table/react-table.css";
import "./LibraryStyling.css"

var response = getBooksFromServer(function (response) {
    console.log(response);
    return response;
});

var reponseafter;
export default class Library extends React.Component {
    
    constructor() {
        super();
        this.state = {
            booksInXML:[]
        }
        //this.handleClick();
      
        //this.handleClick = this.handleClick.bind(this)
    }
    onLoad = async () => {

        await getBooksFromServer(function (res) {

            response = res;
        })


    }
    onClick = async () => {
        //getBooksFromServer(callback);
        var response1 = await ({
            
            booksInXML: getBooksFromServer(await function (res) {
                
                response = res;
                return res;
            }),
            
        });
        //reponseafter = response;
        console.debug(response);
        var convert = require('xml-js');
        var result2 = convert.xml2json(response, { compact: false, spaces: 100 });
        
        console.debug(result2);
    };

    render() {
        return (
            <div onChange={() => this.onLoad()} className='outside'>
                <button onClick={() => this.onClick()} className='button'>
                    Click Me
                </button>
                
                
                
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
