var pkg = require('./package.json');
var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var findImports = require('find-imports');
var stylusLoader = require('stylus-loader');
var nib = require('nib');
var publicname = pkg.name.replace(/^@\w+\//, ''); // Strip out "@trendmicro/" from package name
var banner = [
    publicname + ' v' + pkg.version,
    '(c) ' + new Date().getFullYear() + ' Trend Micro Inc.',
    pkg.license,
    pkg.homepage
].join(' | ');

var localClassPrefix = publicname.replace(/^react-/, ''); // Strip out "react-" from publicname

        
        externals: []
            .concat(findImports(['src/**/*.{js,jsx}'], { flatten: true }))
            .concat(pkg.peerDependencies ? Object.keys(pkg.peerDependencies) :[])
            .concat(pkg.peerDependencies ? Object.keys(pkg.dependencies): []),



module.exports = {
    mode: 'development',
    context: __dirname ,
            entry: "./app.js",
   
        
        output: {
        path: __dirname + "/dist",
        filename: "bundle.js"
            },
            resolve: {
                extensions: ['*', '.js', '.jsx']
            },
            /*exclude: [/\.js$/, /\.html$/, /\.json$/, /\.ejs$/],
            loader: require.resolve('file-loader'),
            options: {
                name: 'static/media/[name].[hash:8].[ext]',
            },
            */
           
            watch: true,
            
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env', '@babel/preset-react']
                    },
                }
            },
            
            {
                test: /\.styl$/,
                loader: 'stylint-loader',
                enforce: 'pre'
            },
            
            {
                test: /\.styl$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader',
                    use: 'css-loader?camelCase&modules&importLoaders=1&localIdentName=' + localClassPrefix + '---[local]---[hash:base64:5]!stylus-loader'
                })
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader'
            },
            {
                test: /\.(png|jpg|svg)$/,
                loader: 'url-loader'
            },

        ],

    }
    }
