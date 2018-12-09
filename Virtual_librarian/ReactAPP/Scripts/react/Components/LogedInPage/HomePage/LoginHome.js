import React, { Component } from 'react';
import Plx from 'react-plx';
import animateScroll from 'animated-scroll-to';
import './HomeStyle.scss';

import PropTypes from 'prop-types';
import BezierEasing from 'bezier-easing';
import ScrollManager from 'window-scroll-manager';

// An array of parallax effects to be applied - see below for detail
const content = [
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
const parallaxData = [
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
const parallaxData1 = [
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
const parallaxData2 = [
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


export default class LoginHome extends React.Component {
    handleScrollTop() {
        animateScroll(0, { minDuration: 3000 });
    }
    render() {
        return (
            <div className = 'Demo'>
                <div style={{ marginLeft: 65 }}>
                    <div className='Content'>
                
                        <Plx
                            tagName='h1'
                            className='Examples'
                            parallaxData={content}
                            
                        >
                            Triangles
                        </Plx>
                        <div className='StickyText-trigger' />
                            <Plx
                                
                                className='StickyText'
                            parallaxData={parallaxData}
                            
                            >
                            Make elements fly in and stick for some time before they fly out
                            </Plx>
                       
                    </div>
                    {/* <div className='Footer'>
                        <div className='Content'>
                            <h1>Plx</h1>
                            <h2>React Parallax component</h2>
                            <div>Awesome isn&#39;t it?</div>
                            <div className='Footer-links'>
                                <a href='https://muffinman.io'>My blog</a>
                                <a href='https://www.npmjs.com/package/react-plx'>npm</a>
                                <a href='https://github.com/Stanko/react-plx'>GitHub</a>
                            </div>
                            <button onClick={() => this.handleScrollTop()}>Back to top</button>
                        </div>
                    </div>*/}
                    {/*
                <div className='StickyText-trigger1' />
                    <Plx
                    className='StickyText'
                    parallaxData={parallaxData1}
                >
                    <h2>Make elements fly in and stick for some time before they fly out</h2>
                </Plx>
                <div className='StickyText-trigger2' />
                <Plx
                    className='StickyText'
                    parallaxData={parallaxData2}
                >
                    <h2>Make elements fly in and stick for some time before they fly out</h2>
                </Plx>
                */}
                </div>
            </div>
        );
    }
}