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
var react_plx_1 = require("react-plx");
var animated_scroll_to_1 = require("animated-scroll-to");
require("./HomeStyle.scss");
// An array of parallax effects to be applied - see below for detail
var content = [
    {
        start: 0,
        startOffset: 50,
        duration: 200,
        properties: [
            {
                startValue: 1,
                endValue: -360,
                property: 'rotate',
            },
            {
                startValue: '#e34e47',
                endValue: '#995eb2',
                property: 'color',
            },
        ],
    },
];
var parallaxData = [
    {
        start: '.StickyText-trigger',
        duration: '30vh',
        properties: [
            {
                startValue: 0,
                endValue: -50,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 0,
                endValue: 1,
                property: 'opacity',
            },
        ],
    },
    {
        start: '.StickyText-trigger',
        startOffset: '60vh',
        duration: '30vh',
        properties: [
            {
                startValue: -50,
                endValue: -100,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 1,
                endValue: 0,
                property: 'opacity',
            },
        ],
    },
];
var parallaxData1 = [
    {
        start: '.StickyText-trigger1',
        duration: '30vh',
        properties: [
            {
                startValue: 0,
                endValue: -50,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 0,
                endValue: 1,
                property: 'opacity',
            },
        ],
    },
    {
        start: '.StickyText-trigger1',
        startOffset: '60vh',
        duration: '30vh',
        end: '1100vh',
        properties: [
            {
                startValue: -50,
                endValue: -100,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 1,
                endValue: 0,
                property: 'opacity',
            },
        ],
    },
];
var parallaxData2 = [
    {
        start: '.StickyText-trigger2',
        duration: '30vh',
        properties: [
            {
                startValue: 0,
                endValue: -50,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 0,
                endValue: 1,
                property: 'opacity',
            },
        ],
    },
    {
        start: '.StickyText-trigger2',
        startOffset: '60vh',
        duration: '30vh',
        properties: [
            {
                startValue: -50,
                endValue: -100,
                unit: 'vh',
                property: 'translateY',
            },
            {
                startValue: 1,
                endValue: 0,
                property: 'opacity',
            },
        ],
    },
];
var LoginHome = /** @class */ (function (_super) {
    __extends(LoginHome, _super);
    function LoginHome() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    LoginHome.prototype.handleScrollTop = function () {
        animated_scroll_to_1.default(0, { minDuration: 3000 });
    };
    LoginHome.prototype.render = function () {
        return (<div className='Demo'>
                <div style={{ marginLeft: 65 }}>
                    <div className='Content'>
                
                        <react_plx_1.default tagName='h1' className='Examples' parallaxData={content}>
                            Triangles
                        </react_plx_1.default>
                        <div className='StickyText-trigger'/>
                            <react_plx_1.default className='StickyText' parallaxData={parallaxData}>
                            Make elements fly in and stick for some time before they fly out
                            </react_plx_1.default>
                       
                    </div>
                    
                    
                </div>
            </div>);
    };
    return LoginHome;
}(react_1.default.Component));
exports.default = LoginHome;
//# sourceMappingURL=../../../../../Components/LogedInPage/HomePage/LoginHome.js.map