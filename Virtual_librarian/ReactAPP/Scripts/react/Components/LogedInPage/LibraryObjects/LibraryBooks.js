import React from "react";
import { render } from "react-dom";
import { makeData, Logo, Tips } from "./Utils";
import axios from 'axios';

// Import React Table
import ReactTable from "react-table";
import "react-table/react-table.css";
import "./LibraryStyling.css"


export default class LibraryBooks extends React.Component {
    constructor() {
        super();
        this.state = {
            allReaderBooks: []
        };
    }

    componentDidMount() {
        let xmls =
            '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">\
            <soap:Body>\
                <GetReadersBooks xmlns="api/BookService">\
                    <readerId>' + localStorage.getItem('userId') + '</readerId>\
                </GetReadersBooks>\
            </soap:Body>\
            </soap:Envelope>';

        axios.post('http://localhost:52312/BookService.asmx?wsdl',
            xmls,
            {
                headers:
                {
                    'Content-Type': 'text/xml',
                    SOAPAction: 'api/BookService/GetReadersBooks'
                }
            }).then(response => {

                var XMLParser = require('react-xml-parser');
                var InXML = new XMLParser().parseFromString(response.data);
                var readerBooksInXML = InXML.getElementsByTagName('Book');

                var readerBooksWithProperties = [];
                var oneBook;

                for (var i = 0; i < readerBooksInXML.length; i++) {
                    oneBook = {};
                    oneBook.name = readerBooksInXML[i].children[1].value;
                    oneBook.author = readerBooksInXML[i].children[2].value;
                    oneBook.publisher = readerBooksInXML[i].children[3].value;
                    oneBook.year = readerBooksInXML[i].children[4].value;
                    oneBook.pages = readerBooksInXML[i].children[5].value;
                    oneBook.isbn = readerBooksInXML[i].children[6].value;
                    oneBook.code = readerBooksInXML[i].children[7].value;

                    //console.log(oneBook);
                    readerBooksWithProperties.push(oneBook);
                }

                //console.log(readerBooksWithProperties);

                this.setState({
                    allReaderBooks: readerBooksWithProperties
                });
            }).catch(err => {
                console.log("Neįmanoma užkrauti skaitytojo knygų sąrašo");
            });
    }

    render() {
        const columns = [{
            Header: 'Pavadinimas',
            accessor: 'name'
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
            <div className="outside">
                <h1>Mano paimtos knygos</h1>
                <ReactTable
                    data={this.state.allReaderBooks}
                    columns={columns}
                    defaultPageSize={10}
                    className="-striped -highlight"
                />
            </div>
        );
    }
}