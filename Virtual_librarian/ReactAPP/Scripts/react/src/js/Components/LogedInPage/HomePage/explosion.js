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
require("./Homepage.scss");
var BOXES_PER_ROW = 4;
var ROWS = 4;
var BOXES = [];
var COLORS = [
    '#2abb9c',
    '#39cb74',
    '#3a99d9',
    '#9a5cb4',
    '#239f85',
    '#30ad62',
    '#2f81b7',
    '#8d48ab',
    '#f0c330',
    '#e47d31',
    '#e54d42',
    '#95a5a6',
    '#f19b2c',
    '#d15419',
    '#be3a31',
    '#7f8c8d',
];
for (var i = 0; i < ROWS; i++) {
    BOXES.push([]);
    for (var j = 0; j < BOXES_PER_ROW; j++) {
        var top_1 = i < ROWS / 2;
        var yFactor = top_1 ? -1 : 1;
        var left = j < BOXES_PER_ROW / 2;
        var xFactor = left ? -1 : 1;
        var inside = (i === 1 || i === 2) && (j === 1 || j === 2); // I was lazy to write generic formula
        var scaleFactor = inside ? 0.5 : 1;
        var start = inside ? 40 : 100;
        var offset = inside ? 40 : 100;
        var rotationFactor = Math.random() > 0.5 ? 180 : -180;
        var color = COLORS[i * ROWS + j];
        BOXES[i].push({
            data: [
                {
                    start: 'self',
                    startOffset: '40vh',
                    duration: 500,
                    name: 'first',
                    properties: [
                        {
                            startValue: 1,
                            endValue: 0,
                            property: 'opacity',
                        },
                        {
                            startValue: 0,
                            endValue: Math.random() * rotationFactor,
                            property: 'rotate',
                        },
                        {
                            startValue: 1,
                            endValue: 1 + Math.random() * scaleFactor,
                            property: 'scale',
                        },
                        {
                            startValue: 0,
                            endValue: (start + Math.random() * offset) * xFactor,
                            property: 'translateX',
                            unit: '%',
                        },
                        {
                            startValue: 0,
                            endValue: (start + Math.random() * offset) * yFactor,
                            property: 'translateY',
                            unit: '%',
                        },
                    ],
                },
            ],
            style: {
                backgroundColor: color,
            },
        });
    }
}
var Explosion = /** @class */ (function (_super) {
    __extends(Explosion, _super);
    function Explosion() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Explosion.prototype.renderBoxes = function () {
        var boxes = [];
        BOXES.forEach(function (row, index) {
            row.forEach(function (box, boxIndex) {
                boxes.push(<react_plx_1.default key={index + " " + boxIndex} className='Explosion-box' parallaxData={box.data} style={box.style}/>);
            });
        });
        return boxes;
    };
    Explosion.prototype.render = function () {
        return (<div className='Explosion'>
                {this.renderBoxes()}
            </div>);
    };
    return Explosion;
}(react_1.default.Component));
exports.default = Explosion;
//# sourceMappingURL=../../../../../Components/LogedInPage/HomePage/explosion.js.map