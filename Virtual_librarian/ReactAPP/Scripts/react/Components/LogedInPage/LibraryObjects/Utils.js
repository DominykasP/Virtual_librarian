import React from "react";
import namor from "namor";
import "./index.css";
import axios from 'axios'

const range = len => {
  const arr = [];
  for (let i = 0; i < len; i++) {
    arr.push(i);
  }
  return arr;
};

const newPerson = () => {
  const statusChance = Math.random();
  return {
    firstName: namor.generate({ words: 1, numbers: 0 }),
    lastName: namor.generate({ words: 1, numbers: 0 }),
    age: Math.floor(Math.random() * 30),
    visits: Math.floor(Math.random() * 100),
    progress: Math.floor(Math.random() * 100),
    status:
      statusChance > 0.66
        ? "relationship"
        : statusChance > 0.33 ? "complicated" : "single"
  };
};

export function getBooksFromServer(callback) {
    /*
    console.log('Success!');
    axios.get('http://localhost:52312/BookService.asmx/GetAllBooks')
        .then(response => this.setState({ booksFromServer: response}))
    */

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
        }).then(res => {
            //console.log(res);
            var XMLParser = require('react-xml-parser');
            var InXML = new XMLParser().parseFromString(res.data);
            var booksInXML = InXML.getElementsByTagName('Book');
            //console.log(booksInXML);
            callback(res);
            //return booksInXML;
        }).catch(Error => {
            console.log(Error.response.data)
            //return err.response.data;
        });
}

export function makeData(len = 5) {
  return range(len).map(d => {
    return {
      ...newPerson(),
      children: range(10).map(newPerson)
    };
  });
}

export const Logo = () =>
  <div style={{ margin: '20rem auto', display: 'flex', flexWrap: 'wrap', alignItems: 'center', justifyContent: 'center'}}>
        {/*For more examples, visit {''}
  <br />
    <a href="https://github.com/react-tools/react-table" target="_blank">
               <img
                src="https://github.com/react-tools/media/raw/master/logo-react-table.png"
                style={{ width: `150px`, margin: ".5em auto .3em" }}
            />
    </a>*/}
  </div>;

export const Tips = () =>
  <div style={{ textAlign: "center" }}>
    <em>Tip: Hold shift when sorting to multi-sort!</em>
  </div>;