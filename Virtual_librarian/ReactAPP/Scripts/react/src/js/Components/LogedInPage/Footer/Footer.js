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
require("./_sticky-footer.css");
var Footer = /** @class */ (function (_super) {
    __extends(Footer, _super);
    function Footer() {
        var _this = _super.call(this) || this;
        var today = new Date(), date = today.getFullYear();
        _this.state = {
            date: date
        };
        return _this;
    }
    Footer.prototype.render = function () {
        var today = new Date();
        return (<div className="Site-content:after">
                <hr />
                <div className="backgroundCol">
                    <footer>
                        <h1>@{this.state.date} - Virtual Librarian</h1>
                </footer>
                    </div>
            </div>);
    };
    return Footer;
}(react_1.default.Component));
exports.default = Footer;
//# sourceMappingURL=../../../../../Components/LogedInPage/Footer/Footer.js.map