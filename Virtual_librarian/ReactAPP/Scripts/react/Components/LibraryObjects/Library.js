import React, { useCallback } from "react";
import { render } from "react-dom";
import { makeData, getBooksFromServer, Logo, Tips } from "./Utils";
import axios from 'axios';

// Import React Table
import ReactTable from "react-table";
import "react-table/react-table.css";
import "./LibraryStyling.css"

export default class Library extends React.Component {
    constructor() {
        super();
        this.state = {
            /*
            booksInXML: getBooksFromServer(function (response) {
                console.log(response);
            }),
            */
            allBooks: [],
            data: makeData()
        };
        //this.handleClick();

        //this.handleClick = this.handleClick.bind(this)
    }

    componentDidMount() {
        let xmls =
            '<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">\
            <soap12:Body>\
                    <GetAllBooks xmlns="api/BookService" />\
                </soap12:Body>\
            </soap12:Envelope>';

        axios.post('http://localhost:52312/BookService.asmx?wsdl',
            xmls,
            {
                headers:
                {
                    'Content-Type': 'text/xml',
                    SOAPAction: 'api/BookService/GetAllBooks'
                }
            }).then(response => {
                
                var XMLParser = require('react-xml-parser');
                var InXML = new XMLParser().parseFromString(response.data);
                var allBooksInXML = InXML.getElementsByTagName('Book');

                var allBooksWithProperties = [];
                var oneBook;

                for (var i = 0; i < allBooksInXML.length; i++) {
                    oneBook = {};
                    oneBook.name = allBooksInXML[i].children[1].value;
                    oneBook.author = allBooksInXML[i].children[2].value;
                    oneBook.publisher = allBooksInXML[i].children[3].value;
                    oneBook.year = allBooksInXML[i].children[4].value;
                    oneBook.pages = allBooksInXML[i].children[5].value;
                    oneBook.isbn = allBooksInXML[i].children[6].value;
                    oneBook.code = allBooksInXML[i].children[7].value;

                    console.log(oneBook);
                    allBooksWithProperties.push(oneBook);
                }

                console.log(allBooksWithProperties);
                
                this.setState({
                    allBooks: allBooksWithProperties
                });
            }).catch(err => {
                console.log("Neįmanoma užkrauti visų knygų sąrašo");
            });
    }

    render() {
        const columns = [{
                Header: 'Pavadinimas',
                accessor: 'name' // String-based value accessors!
            }, {
                Header: 'Autorius',
                accessor: 'author',
            }, {
                Header: 'Leidėjas',
                accessor: 'publisher',
            }, {
                Header: 'Išleidimo metai',
                accessor: 'year',
            }, {
                Header: 'Puslapių skaičius',
                accessor: 'pages',
            }, {
                Header: 'ISBN',
                accessor: 'isbn',
            }, {
                Header: 'Kodas',
                accessor: 'code',
            }];

        return (
            <div className='outside'>
                <h1>Visos bibliotekos knygos</h1>
                <ReactTable
                    data={this.state.allBooks}
                    columns={columns}
                    defaultPageSize={10}
                    className="-striped -highlight"
                />
                
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
