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
var Library = /** @class */ (function (_super) {
    __extends(Library, _super);
    function Library() {
        var _this = _super.call(this) || this;
        _this.state = {
            allBooks: []
        };
        return _this;
    }
    Library.prototype.componentDidMount = function () {
        var _this = this;
        var xmls = '<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">\
            <soap12:Body>\
                    <GetAllBooks xmlns="api/BookService" />\
                </soap12:Body>\
            </soap12:Envelope>';
        axios_1.default.post('http://localhost:52312/BookService.asmx?wsdl', xmls, {
            headers: {
                'Content-Type': 'text/xml',
                SOAPAction: 'api/BookService/GetAllBooks'
            }
        }).then(function (response) {
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
                //console.log(oneBook);
                allBooksWithProperties.push(oneBook);
            }
            //console.log(allBooksWithProperties);
            _this.setState({
                allBooks: allBooksWithProperties
            });
        }).catch(function (err) {
            console.log("Neįmanoma užkrauti visų knygų sąrašo");
        });
    };
    Library.prototype.render = function () {
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
        return (<div className='outside'>
                <h1>Visos bibliotekos knygos</h1>
                <react_table_1.default data={this.state.allBooks} columns={columns} defaultPageSize={10} className="-striped -highlight"/>
            </div>);
    };
    return Library;
}(react_1.default.Component));
exports.default = Library;
//# sourceMappingURL=../../../../../Components/LogedInPage/LibraryObjects/Library.js.map