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
require("./margins.scss");
var react_router_dom_1 = require("react-router-dom");
var Settings_1 = require("./Settings");
var LoginHome_1 = require("./HomePage/LoginHome");
var Devices_1 = require("./Devices");
var Library_1 = require("./LibraryObjects/Library");
var LibraryBooks_1 = require("./LibraryObjects/LibraryBooks");
var react_sidenav_1 = require("@trendmicro/react-sidenav");
var Contacts_1 = require("./Contacts");
var LibraryHome = /** @class */ (function (_super) {
    __extends(LibraryHome, _super);
    function LibraryHome(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            IDd: 'labas'
        };
        return _this;
        //console.log(props.location.state.id)
        //console.log(this.props.location.state.id);
    }
    LibraryHome.prototype.render = function () {
        //console.log(this.props.location.state.ID);
        return (<div className="nomargins">
                
                <react_router_dom_1.Route path="/library" render={function (_a) {
            var location = _a.location, history = _a.history;
            return (<react_1.default.Fragment>
                        <react_sidenav_1.default onSelect={function (selected) {
                var to = '/' + selected;
                if (location.pathname !== to) {
                    history.push(to);
                }
            }}>
                            <react_sidenav_1.default.Toggle />
                            <react_sidenav_1.default.Nav defaultSelected="/">
                                <react_sidenav_1.NavItem eventKey="library/home">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fa fa-fw fa-home" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        Home 
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                                
                                <react_sidenav_1.NavItem eventKey="library/devices">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fa fa-laptop" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        Devices
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                                <react_sidenav_1.NavItem eventKey="library/library">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fas fa-book-reader" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        Library
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                                <react_sidenav_1.NavItem eventKey="library/mybooks">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fa fa-book" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        My Books
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                                <react_sidenav_1.NavItem eventKey="library/contacts">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fas fa-address-book" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        Contacts
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                                <react_sidenav_1.NavItem eventKey="login">
                                    <react_sidenav_1.NavIcon>
                                        <i className="fas fa-sign-out-alt" style={{ fontSize: '1.75em' }}/>
                                    </react_sidenav_1.NavIcon>
                                    <react_sidenav_1.NavText>
                                        Sign Out
                        </react_sidenav_1.NavText>
                                </react_sidenav_1.NavItem>
                            </react_sidenav_1.default.Nav>
                        </react_sidenav_1.default>
                        <main>
                            <react_router_dom_1.Route exact={true} path="/library" render={function () { return (<h1>Welcome </h1>); }}/>
                            
                            <react_router_dom_1.Route path="/library/home" component={LoginHome_1.default}/>                           
                            <react_router_dom_1.Route path="/library/devices" component={function (props) { return <Devices_1.default />; }}/>
                            <react_router_dom_1.Route path="/library/library" component={Library_1.default}/>
                            <react_router_dom_1.Route path="/library/mybooks" component={LibraryBooks_1.default}/>
                            <react_router_dom_1.Route path="/library/contacts" component={Contacts_1.default}/>
                            <react_router_dom_1.Route path="login"/>
                        </main>
                    </react_1.default.Fragment>);
        }}/>
            </div>);
    };
    return LibraryHome;
}(react_1.default.Component));
exports.default = LibraryHome;
Settings_1.default.id = "app";
//# sourceMappingURL=../../../../Components/LogedInPage/LibraryHome.js.map