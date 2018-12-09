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
require("antd/dist/antd.css");
var virtual_librarian_main_page_png_1 = require("./LogedInPage/images/virtual-librarian-main-page.png");
require("./LogedInPage/margins.scss");
var sectionStyle = {
    marginTop: "-60px",
    width: "1500px",
    height: "879px",
    backgroundImage: "url(" + virtual_librarian_main_page_png_1.default + ")"
};
var Home = /** @class */ (function (_super) {
    __extends(Home, _super);
    function Home() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Home.prototype.render = function () {
        return (<div>
                <div>
                    <img className="picture" src={virtual_librarian_main_page_png_1.default} alt="Background"/>
                    <div>   
                    
                        <div className="LinkColor">
                        </div>
                    </div>
                </div>
            </div>);
    };
    return Home;
}(react_1.default.Component));
exports.default = Home;
Home.id = "app";
//# sourceMappingURL=../../../Components/Home.js.map