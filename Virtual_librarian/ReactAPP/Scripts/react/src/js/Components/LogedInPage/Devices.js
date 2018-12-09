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
var Devices = /** @class */ (function (_super) {
    __extends(Devices, _super);
    function Devices(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            isGoing: true,
            numberOfGuests: 2
        };
        _this.handleInputChange = _this.handleInputChange.bind(_this);
        return _this;
    }
    Devices.prototype.handleInputChange = function (event) {
        var _a;
        var target = event.target;
        var value = target.type === 'checkbox' ? target.checked : target.value;
        var name = target.name;
        this.setState((_a = {},
            _a[name] = value,
            _a));
    };
    Devices.prototype.render = function () {
        return (<div className="outside">
            <h1>Kazkas</h1>
                <form>
                    <label>
                        Is going:
          <input name="IsGoing" type="checkbox" checked={this.state.isGoing} onChange={this.handleInputChange}/>
                    </label>
                    <br />
                    <label>
                        Number of guests:
          <input name="numberOfGuests" type="number" value={this.state.numberOfGuests} onChange={this.handleInputChange}/>
                    </label>
                </form>
                </div>);
    };
    return Devices;
}(react_1.default.Component));
exports.default = Devices;
Devices.id = "app";
//# sourceMappingURL=../../../../Components/LogedInPage/Devices.js.map