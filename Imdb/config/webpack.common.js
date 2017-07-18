﻿var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var helpers = require('./helpers');

module.exports = {
    entry: {
        'polyfills': './src/polyfills.ts',
        'vendor': './src/vendor.ts',
        'app': './src/main.ts'
    },

    resolve: {
        extensions: ['.ts', '.js', '.css', '.scss']
    },

    module: {
        rules: [
            {
                test: /\.ts$/,
                loaders: [
                    {
                        loader: 'awesome-typescript-loader',
                        options: { configFileName: helpers.root('src', 'tsconfig.json') }
                    }, 'angular2-template-loader'
                ]
            },
            {
                test: /\.html$/,
                loader: 'html-loader'
            },
            {
                test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                loader: 'file-loader?name=assets/[name].[hash].[ext]'
            },
            {
                test: /\.css$/,
                exclude: helpers.root('src', 'app'),
                loader: ExtractTextPlugin.extract({ fallbackLoader: 'style-loader', loader: 'css-loader?sourceMap' })
            },
            {
                test: /\.css$/,
                include: helpers.root('src', 'app'),
                loader: 'raw-loader'
            },
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                loaders: ['raw-loader', 'sass-loader']
            }
        ]
    },

    plugins: [
        // Workaround for angular/angular#11580
        //new webpack.ContextReplacementPlugin(
        //  // The (\\|\/) piece accounts for path separators in *nix and Windows
        //  /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
        //  helpers.root('./src'), // location of your src
        //  {} // a map of your routes
        //),

        new webpack.optimize.CommonsChunkPlugin({
            name: ['app', 'vendor', 'polyfills']
        }),

    ]
};





/* using tree shaking */
/*

var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var helpers = require('./helpers');

var CommonsChunkPlugin = require('webpack/lib/optimize/CommonsChunkPlugin');


module.exports = {
  entry: {
    'polyfills': './src/polyfills.ts',
    //'vendor': './src/vendor.ts',
    'app': './src/main.ts'
  },

  resolve: {
      extensions: ['.ts', '.js', '.css', '.scss']
  },

  module: {
    rules: [
      {
        test: /\.ts$/,
        loaders: [
          {
            loader: 'awesome-typescript-loader',
            options: { configFileName: helpers.root('src', 'tsconfig.json') }
          } , 'angular2-template-loader'
        ]
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      },
      {
        test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
        loader: 'file-loader?name=assets/[name].[hash].[ext]'
      },
      {
        test: /\.css$/,
        exclude: helpers.root('src', 'app'),
        loader: ExtractTextPlugin.extract({ fallbackLoader: 'style-loader', loader: 'css-loader?sourceMap' })
      },
      {
        test: /\.css$/,
        include: helpers.root('src', 'app'),
        loader: 'raw-loader'
      },
      {
          test: /\.scss$/,
          //exclude: /node_modules/,
          loaders: ['raw-loader', 'sass-loader']
      }
    ]
  },

  plugins: [
    // Workaround for angular/angular#11580
    //new webpack.ContextReplacementPlugin(
    //  // The (\\|\/) piece accounts for path separators in *nix and Windows
    //  /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
    //  helpers.root('./src'), // location of your src
    //  {} // a map of your routes
    //),

    //new webpack.optimize.CommonsChunkPlugin({
    //  name: ['app', 'vendor', 'polyfills']
    //}),


      new CommonsChunkPlugin({
          name: 'polyfills',
          chunks: ['polyfills']
      }),
      // This enables tree shaking of the vendor modules
      new CommonsChunkPlugin({
          name: 'vendor',
          chunks: ['app'],
          minChunks: module => /node_modules/.test(module.resource)
      }),
      // Specify the correct order the scripts will be injected in
      new CommonsChunkPlugin({
          name: ['polyfills', 'vendor'].reverse()
      }),


    //new HtmlWebpackPlugin({
    //  template: 'Views/Index/Index.cshtml'
    //})
  ]
};



*/