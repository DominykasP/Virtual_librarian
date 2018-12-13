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
var Utils_1 = require("./Utils");
require("../LogedInPage/margins.scss");
var styles_1 = require("@material-ui/core/styles");
var classnames_1 = require("classnames");
var purple_1 = require("@material-ui/core/colors/purple");
var green_1 = require("@material-ui/core/colors/green");
var material_ui_next_pickers_1 = require("material-ui-next-pickers");
var TextField_1 = require("@material-ui/core/TextField");
var Button_1 = require("@material-ui/core/Button");
require("babel-polyfill");
var reactstrap_1 = require("reactstrap");
var theme = styles_1.createMuiTheme({
    palette: {
        primary: green_1.default,
    },
    typography: {
        useNextVariants: true,
    },
});
var styles = function (theme) { return ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        marginTop: '1px',
    },
    margin: {
        margin: theme.spacing.unit,
    },
    textField: {
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        width: 200,
    },
    cssRoot: {
        color: theme.palette.getContrastText(purple_1.default[500]),
        backgroundColor: green_1.default[500],
        '&:hover': {
            backgroundColor: green_1.default[700],
        },
    },
    dense: {
        marginTop: 19,
    },
    menu: {
        width: 200,
    },
    resizeFont: {
        fontSize: 12,
    },
}); };
/*const year = new Date().getFullYear();
const items = [];
for (let i = 0; i < 100; i++) {
    items.push(<MenuItem value={year - 100} key={i} primaryText={`${i}`} />);
}*/
var callback;
var useCallback;
var ID = 10;
var Register = /** @class */ (function (_super) {
    __extends(Register, _super);
    function Register() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.state = {
            username: '',
            surname: '',
            email: '',
            password: '',
            repeatpassword: '',
            datenew: '',
            exists: 0,
            phonenumber: '',
        };
        _this.handleChange = function (name) { return function (event) {
            var _a;
            _this.setState((_a = {},
                _a[name] = event.target.value,
                _a));
        }; };
        _this.onChangeDate = function (date) {
            console.log('Date: ', date);
            _this.setState({ date: date });
            var date = new Date(date);
            var finaldate = date.getFullYear() + '-' + (date.getMonth() + 1) + '-';
            if (date.getDate() < 10) {
                finaldate = finaldate + '0' + date.getDate();
            }
            else {
                finaldate = finaldate + date.getDate();
            }
            _this.state.datenew = finaldate;
            console.log("-" + _this.state.datenew + "-");
        };
        _this.onSubmit = function () { return __awaiter(_this, void 0, void 0, function () {
            var get, XMLParser, InXML, UserinXML, add;
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
                        this.state.exists = UserinXML[0].children.length;
                        console.log(this.state.exists);
                        if (!(this.state.exists == 0)) return [3 /*break*/, 3];
                        return [4 /*yield*/, Utils_1.addPersonByRegisterData(ID, this.state.username, this.state.surname, this.state.password, this.state.datenew, this.state.phonenumber, this.state.email, useCallback).then(function (response) {
                                //console.log(response);
                                useCallback = response;
                                return useCallback;
                            })];
                    case 2:
                        add = _a.sent();
                        return [3 /*break*/, 3];
                    case 3:
                        console.log(useCallback);
                        return [2 /*return*/];
                }
            });
        }); };
        return _this;
    }
    Register.prototype.render = function () {
        var _this = this;
        var classes = this.props.classes;
        var date = this.state.date;
        return (<div background-size='cover' className="hero">

                <reactstrap_1.Container>
                    <div style={{ marginTop: 50 }} className="homepage">
                    <h2>Sign Up</h2>
                    <form className={classes.container} noValidate>
                       
                        <TextField_1.default id="username" label="Name" className={classes.textField} value={this.state.username} onChange={this.handleChange('username')} margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}/>
                       
                        <TextField_1.default id="surename" label="Surname" className={classes.textField} value={this.state.surname} onChange={this.handleChange('surname')} margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginTop: 30, marginBottom: 30 }}/>
                            <div style={{ marginLeft: 92 }}>
                                <styles_1.MuiThemeProvider>
                                <material_ui_next_pickers_1.DateFormatInput label="Birth Date" min={new Date('1950-1-1, 6:37 pm')} className={classes.textField} name='date-input' dateFormat="MMMM d, yyyy" margin="normal" value={date} style={{ marginLeft: 50000, marginTop: 100, }} onChange={this.onChangeDate}/>
                                    </styles_1.MuiThemeProvider>
                       </div>
                        <TextField_1.default id="email" label="Email" className={classes.textField} value={this.state.email} onChange={this.handleChange('email')} margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}/>
                        <TextField_1.default id="email" label="Phone Number" className={classes.textField} value={this.state.phonenumber} onChange={this.handleChange('phonenumber')} margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}/>
                        <TextField_1.default id="password" label="Password" className={classes.textField} value={this.state.password} onChange={this.handleChange('password')} type="password" autoComplete="current-password" margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}/>
                        <TextField_1.default id="repeatpassword" label="Repeat Password" className={classes.textField} value={this.state.repeatpassword} onChange={this.handleChange('repeatpassword')} type="password" autoComplete="repeat-password" margin="normal" InputProps={{
            classes: {
                input: classes.resizeFont,
            },
        }} style={{ marginLeft: 100, marginRight: 120, marginTop: 30, }}/>
                           
                    </form>
                        <react_router_dom_1.Link to="/login">
                            <Button_1.default size="large" variant="contained" color="primary" className={classnames_1.default(classes.margin, classes.cssRoot)}>
                                Register
                                </Button_1.default>
                        </react_router_dom_1.Link>  
                    <react_router_dom_1.Link to="/login">
                        <Button_1.default onClick={function () { return _this.onSubmit(); }} color="primary">Cancel</Button_1.default>
                        </react_router_dom_1.Link>  
                        
                    </div>
                    </reactstrap_1.Container>
                    </div>);
    };
    return Register;
}(react_1.default.Component));
exports.default = styles_1.withStyles(styles)(Register);
Register.id = "app";
//# sourceMappingURL=../../../../Components/authentication/Register.js.map