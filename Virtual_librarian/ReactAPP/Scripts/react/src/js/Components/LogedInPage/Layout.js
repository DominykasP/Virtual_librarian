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
var react_router_dom_1 = require("react-router-dom");
require("./margins.scss");
var LayoutMy = /** @class */ (function (_super) {
    __extends(LayoutMy, _super);
    function LayoutMy() {
        var _this = _super.call(this) || this;
        _this.state = { name: "zmogau" };
        return _this;
    }
    LayoutMy.prototype.render = function () {
        // const title = "get react";
        // setTimeout(() => {
        //      this.setState({ name: "Bob" });
        //},3000)
        return (<div>
                
                {this.props.children}
                <react_router_dom_1.Link to="/home"></react_router_dom_1.Link>
                <react_router_dom_1.Link to="archives"></react_router_dom_1.Link>
                <react_router_dom_1.Link to="settings"></react_router_dom_1.Link>
                
            </div>);
    };
    return LayoutMy;
}(react_1.default.Component));
exports.default = LayoutMy;
LayoutMy.id = "app";
//# sourceMappingURL=../../../../Components/LogedInPage/Layout.js.map