"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var react_1 = require("react");
var axios_1 = require("axios");
// Import React Table
var react_table_1 = require("react-table");
require("react-table/react-table.css");
require("./LibraryStyling.css");
var LibraryBooks = /** @class */ (function (_super) {
    __extends(LibraryBooks, _super);
    function LibraryBooks() {
        var _this = _super.call(this) || this;
        _this.state = {
            allReaderBooks: []
        };
        return _this;
    }
    LibraryBooks.prototype.componentDidMount = function () {
        var _this = this;
        var xmls = '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">\
            <soap:Body>\
                <GetReadersBooks xmlns="api/BookService">\
                    <readerId>' + localStorage.getItem('userId') + '</readerId>\
                </GetReadersBooks>\
            </soap:Body>\
            </soap:Envelope>';
        axios_1.default.post('http://localhost:52312/BookService.asmx?wsdl', xmls, {
            headers: {
                'Content-Type': 'text/xml',
                SOAPAction: 'api/BookService/GetReadersBooks'
            }
        }).then(function (response) {
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
            _this.setState({
                allReaderBooks: readerBooksWithProperties
            });
        }).catch(function (err) {
            console.log("Neįmanoma užkrauti skaitytojo knygų sąrašo");
        });
    };
    LibraryBooks.prototype.render = function () {
        var columns = [{
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
        return (<div className="outside">
                <h1>Mano paimtos knygos</h1>
                <react_table_1.default data={this.state.allReaderBooks} columns={columns} defaultPageSize={10} className="-striped -highlight"/>
            </div>);
    };
    return LibraryBooks;
}(react_1.default.Component));
exports.default = LibraryBooks;
//# sourceMappingURL=../../../../../Components/LogedInPage/LibraryObjects/LibraryBooks.js.map