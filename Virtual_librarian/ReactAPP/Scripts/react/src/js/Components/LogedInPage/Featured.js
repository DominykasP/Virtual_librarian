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
var Featured = /** @class */ (function (_super) {
    __extends(Featured, _super);
    function Featured() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Featured.prototype.render = function () {
        return (<div>
                <h1>Featured</h1>
                </div>);
    };
    return Featured;
}(react_1.default.Component));
exports.default = Featured;
//# sourceMappingURL=../../../../Components/LogedInPage/Featured.js.map