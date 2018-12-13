"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var react_1 = require("react");
var react_dom_1 = require("react-dom");
var react_router_dom_1 = require("react-router-dom");
var react_router_dom_2 = require("react-router-dom");
var react_apollo_1 = require("react-apollo");
var apollo_boost_1 = require("apollo-boost");
require("./Components/LogedInPage/margins.scss");
require("@trendmicro/react-sidenav/dist/react-sidenav.css");
var SignIn_1 = require("./Components/authentication/SignIn");
var Layout_1 = require("./Components/LogedInPage/Layout");
var Register_1 = require("./Components/authentication/Register");
var LibraryHome_1 = require("./Components/LogedInPage/LibraryHome");
var client = new apollo_boost_1.default({
    uri: 'https://api-euwest.graphcms.com/v1/cjp05opy767ky01dgqqco0zjz/master',
});
var app = document.getElementById('app');
react_dom_1.default.render(<div>
        
        <react_router_dom_2.HashRouter>
        <Layout_1.default>
                <react_apollo_1.ApolloProvider client={client}>
                    <react_router_dom_1.Route exact path="/" render={function (props) { return <SignIn_1.default {...props}/>; }}/>
                    <react_router_dom_1.Route exact path="/login" render={function (props) { return <SignIn_1.default {...props}/>; }}/>
                    <react_router_dom_1.Route exact path="/register" render={function (props) { return <Register_1.default {...props}/>; }}/>
                </react_apollo_1.ApolloProvider>
           <LibraryHome_1.default />
            
            
         </Layout_1.default>   
        </react_router_dom_2.HashRouter>
        
           
        </div>, app);
//# sourceMappingURL=../../app.js.map