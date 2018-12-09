"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var react_1 = require("react");
var namor_1 = require("namor");
require("./index.css");
var axios_1 = require("axios");
var range = function (len) {
    var arr = [];
    for (var i = 0; i < len; i++) {
        arr.push(i);
    }
    return arr;
};
var newPerson = function () {
    var statusChance = Math.random();
    return {
        firstName: namor_1.default.generate({ words: 1, numbers: 0 }),
        lastName: namor_1.default.generate({ words: 1, numbers: 0 }),
        age: Math.floor(Math.random() * 30),
        visits: Math.floor(Math.random() * 100),
        progress: Math.floor(Math.random() * 100),
        status: statusChance > 0.66
            ? "relationship"
            : statusChance > 0.33 ? "complicated" : "single"
    };
};
function getBooksFromServer(callback) {
    /*
    console.log('Success!');
    axios.get('http://localhost:52312/BookService.asmx/GetAllBooks')
        .then(response => this.setState({ booksFromServer: response}))
    */
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
    }).then(function (res) {
        //console.log(res);
        var XMLParser = require('react-xml-parser');
        var InXML = new XMLParser().parseFromString(res.data);
        var booksInXML = InXML.getElementsByTagName('Book');
        //console.log(booksInXML);
        callback(res);
        //return booksInXML;
    }).catch(function (Error) {
        console.log(Error.response.data);
        //return err.response.data;
    });
}
exports.getBooksFromServer = getBooksFromServer;
function makeData(len) {
    if (len === void 0) { len = 5; }
    return range(len).map(function (d) {
        return __assign({}, newPerson(), { children: range(10).map(newPerson) });
    });
}
exports.makeData = makeData;
exports.Logo = function () {
    return <div style={{ margin: '20rem auto', display: 'flex', flexWrap: 'wrap', alignItems: 'center', justifyContent: 'center' }}>
        
  </div>;
};
exports.Tips = function () {
    return <div style={{ textAlign: "center" }}>
    <em>Tip: Hold shift when sorting to multi-sort!</em>
  </div>;
};
//# sourceMappingURL=../../../../../Components/LogedInPage/LibraryObjects/Utils.js.map