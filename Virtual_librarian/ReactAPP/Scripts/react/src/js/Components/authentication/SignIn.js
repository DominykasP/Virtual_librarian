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
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var react_1 = require("react");
var react_router_dom_1 = require("react-router-dom");
var react_router_1 = require("react-router");
var reactstrap_1 = require("reactstrap");
require("../LogedInPage/margins.scss");
require("antd/dist/antd.css");
var Utils_1 = require("./Utils");
var prop_types_1 = require("prop-types");
var classnames_1 = require("classnames");
var styles_1 = require("@material-ui/core/styles");
var TextField_1 = require("@material-ui/core/TextField");
var Button_1 = require("@material-ui/core/Button");
var purple_1 = require("@material-ui/core/colors/purple");
var green_1 = require("@material-ui/core/colors/green");
var LibraryHome_1 = require("../LogedInPage/LibraryHome");
/*Text box*/
var styles = function (theme) { return ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    button: {
        margin: theme.spacing.unit,
    },
    input: {
        display: 'none',
    },
    margin: {
        margin: theme.spacing.unit,
    },
    cssRoot: {
        color: theme.palette.getContrastText(purple_1.default[500]),
        backgroundColor: green_1.default[500],
        '&:hover': {
            backgroundColor: green_1.default[700],
        },
    },
    textField: {
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        width: 200,
    },
    dense: {
        marginTop: 19,
    },
    menu: {
        width: 200,
    },
    resizeFont: {
        fontSize: 15,
    },
}); };
var callback;
var SignIn = /** @class */ (function (_super) {
    __extends(SignIn, _super);
    /*Button*/
    /*textboxes state*/
    function SignIn(props) {
        var _this = _super.call(this, props) || this;
        _this.login = function () { return __awaiter(_this, void 0, void 0, function () {
            var get, XMLParser, InXML, UserinXML, path;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, Utils_1.getPersonByLoginData(this.state.username, this.state.surname, this.state.password, callback)
                            .then(function (response) {
                            //console.log(response);
                            callback = response;
                            return callback;
                        })];
                    case 1:
                        get = _a.sent();
                        XMLParser = require('react-xml-parser');
                        InXML = new XMLParser().parseFromString(callback.data);
                        UserinXML = InXML.getElementsByTagName('GetPersonByNameSurnamePasswordResponse');
                        console.log(UserinXML);
                        this.state.authenticated = UserinXML[0].children.length;
                        /*console.log(UserinXML[0].children[0].children[0].value);*/
                        console.log("authenticated");
                        console.log(this.state.authenticated);
                        if (UserinXML[0].children.length == 0) {
                            // console.log("yey");
                        }
                        if (this.state.authenticated > 0) {
                            //console.log("yeyyey");
                            //console.log(UserinXML[0].children[0].children[0].value);
                            localStorage.setItem('userId', UserinXML[0].children[0].children[0].value);
                            path = "/library/home";
                            this.state.ID = UserinXML[0].children[0].children[0].value;
                            this.props.history.push({
                                pathname: path,
                                search: '',
                                state: { id: this.state.ID }
                            });
                            //  console.log("after"); 
                        }
                        return [2 /*return*/];
                }
            });
        }); };
        _this.handleChange = function (name) { return function (event) {
            var _a;
            _this.setState((_a = {},
                _a[name] = event.target.value,
                _a));
            console.log(_this.state);
        }; };
        _this.protectedComponent = function () {
            if (_this.state.authenticated == 0) {
                return <react_router_dom_1.Redirect to='/login'/>;
            }
            else if (_this.state.authenticated > 0)
                return <react_router_dom_1.Redirect to='/library/home'/>;
        };
        _this.state = {
            username: '',
            surname: '',
            password: '',
            link: "/login",
            authenticated: 0,
            ID: 0
        };
        _this.login = _this.login.bind(_this);
        _this.handleChange = _this.handleChange.bind(_this);
        _this.protectedComponent = _this.protectedComponent.bind(_this);
        return _this;
    }
    SignIn.prototype.render = function () {
        var classes = this.props.classes;
        var size = this.state.size;
        return (<div className="hero">
                   
                    <reactstrap_1.Container>
                        <div className="homepage">
                            <h2>Sign In</h2>

                            <form className={classes.container} noValidate autoComplete="off">
                                <TextField_1.default id="Username" label="Name" onChange={this.handleChange('username')} value={this.state.username} InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} className={classes.textField} margin="normal" style={{ marginLeft: 575, marginRight: 400 }}/>
                                <TextField_1.default id="Surename" label="Surname" onChange={this.handleChange('surname')} value={this.state.surname} InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} className={classes.textField} margin="normal" style={{ marginLeft: 575, marginRight: 600, marginTop: 30, }}/>
                                <TextField_1.default id="standard-password-input" style={{ marginLeft: 575, marginTop: 120, marginTop: 30, }} label="Password" type="password" title={this.state.name} value={this.state.password} onChange={this.handleChange('password')} InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} className={classes.textField} margin="normal" autoComplete="current-password"/>
                            </form>


                            <Button_1.default size="large" onClick={this.login} variant="contained" color="primary" className={classes.button}>
                                SignIn
                                
                                    </Button_1.default>
                            <react_router_dom_1.Route path="/library" component={LibraryHome_1.default} something={this.state.ID}/>

                            <react_router_dom_1.Link to="/register">
                                <Button_1.default size="large" variant="contained" color="primary" className={classnames_1.default(classes.margin, classes.cssRoot)}>
                                    Register
                                </Button_1.default>
                            </react_router_dom_1.Link>
                                
                            
                        </div>
                    </reactstrap_1.Container>
                    
                </div>);
    };
    return SignIn;
}(react_1.default.Component));
SignIn.propTypes = {
    classes: prop_types_1.default.object.isRequired,
};
SignIn = styles_1.withStyles(styles)(SignIn);
exports.default = react_router_1.withRouter(SignIn);
SignIn.id = "app";
//# sourceMappingURL=../../../../Components/authentication/SignIn.js.map