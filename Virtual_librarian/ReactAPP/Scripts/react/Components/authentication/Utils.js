import React from "react";
import namor from "namor";
import { HashRouter } from 'react-router-dom';
import axios from 'axios'

export async function getPersonByLoginData(name, surname, password,useCallback) {
    var th = this;
    let xmls =
        '<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">\
         <soap12:Body>\
            <GetPersonByNameSurnamePassword xmlns="api/PersonService">\
                <name>' + name + '</name>\
                <surname>' + surname + '</surname>\
                <password>' + password + '</password>\
            </GetPersonByNameSurnamePassword>\
        </soap12:Body >\
        </soap12:Envelope >';
    

  await axios.post('http://localhost:52312/PersonService.asmx?wsdl',
        xmls,
        {
            headers:
            {
                'Content-Type': 'text/xml',
                SOAPAction: "api/PersonService/GetPersonByNameSurnamePassword"
            }
       }).then(function (response) {

           useCallback = response;
           //console.log(useCallback);
           
           
           return useCallback;
            /* atsakymas yra res.data */

        }).catch(err => {
            console.log("unable to load");
        });

    //console.log(useCallback);
    return useCallback;
}
export async function addPersonByRegisterData(ID, name, surname, password, datetime, phoneNumber, email, useCallback) {
    console.log("ID:");
    console.log(ID);
    console.log("name:");
    console.log(name);
    console.log("surname:");
    console.log(surname);
    
    console.log("datetime:");
    console.log(datetime);
    console.log("phone number:");
    console.log(phoneNumber);
    console.log("email:");
    console.log(email);
    var th = this;
    let xmls =
        '<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">\
         <soap12:Body>\
            <AddNewPerson xmlns="api/PersonService">\
                <id>' + ID + '</id>\
                <name>' + name + '</name>\
                <surname>' + surname + '</surname>\
                <password>'+ password + '</password>\
                <birthDate>' + datetime + '</birthDate>\
                <phoneNumber>' + phoneNumber + '</phoneNumber>\
                <email>' + email + '</email>\
            </AddNewPerson>\
          </soap12:Body>\
          </soap12:Envelope>';


    await axios.post('http://localhost:52312/PersonService.asmx?wsdl',
        xmls,
        {
            headers:
            {
                'Content-Type': 'text/xml',
                SOAPAction: "api/PersonService/AddNewPerson"
            }
        }).then(function (response) {

            useCallback = response;
            //console.log(useCallback);


            return useCallback;
            /* atsakymas yra res.data */

        }).catch(err => {
            console.log("unable to load");
        });

    //console.log(useCallback);
    return useCallback;
}
  
   
