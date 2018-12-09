webpackHotUpdate("main",{

/***/ "./node_modules/apollo-boost/lib/index.js":
/*!************************************************!*\
  !*** ./node_modules/apollo-boost/lib/index.js ***!
  \************************************************/
/*! exports provided: gql, HttpLink, default, printAST, ObservableQuery, NetworkStatus, FetchType, ApolloError, ApolloClient, empty, from, split, concat, ApolloLink, execute, createOperation, makePromise, toPromise, fromPromise, fromError, Observable, InMemoryCache, defaultDataIdFromObject, StoreReader, assertIdValue, WriteError, enhanceErrorWithDocument, StoreWriter, HeuristicFragmentMatcher, IntrospectionFragmentMatcher, ObjectCache, defaultNormalizedCacheFactory, RecordingCache, record */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var apollo_client__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! apollo-client */ "./node_modules/apollo-client/index.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "printAST", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["printAST"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ObservableQuery", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["ObservableQuery"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "NetworkStatus", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["NetworkStatus"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "FetchType", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["FetchType"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ApolloError", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["ApolloError"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ApolloClient", function() { return apollo_client__WEBPACK_IMPORTED_MODULE_0__["ApolloClient"]; });

/* harmony import */ var apollo_link__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! apollo-link */ "./node_modules/apollo-link/lib/index.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "empty", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["empty"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "from", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["from"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "split", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["split"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "concat", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["concat"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ApolloLink", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["ApolloLink"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "execute", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["execute"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "createOperation", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["createOperation"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "makePromise", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["makePromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "toPromise", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["toPromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "fromPromise", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["fromPromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "fromError", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["fromError"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "Observable", function() { return apollo_link__WEBPACK_IMPORTED_MODULE_1__["Observable"]; });

/* harmony import */ var apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! apollo-cache-inmemory */ "./node_modules/apollo-cache-inmemory/lib/index.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "InMemoryCache", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["InMemoryCache"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "defaultDataIdFromObject", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["defaultDataIdFromObject"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "StoreReader", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["StoreReader"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "assertIdValue", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["assertIdValue"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "WriteError", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["WriteError"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "enhanceErrorWithDocument", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["enhanceErrorWithDocument"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "StoreWriter", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["StoreWriter"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "HeuristicFragmentMatcher", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["HeuristicFragmentMatcher"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "IntrospectionFragmentMatcher", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["IntrospectionFragmentMatcher"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ObjectCache", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["ObjectCache"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "defaultNormalizedCacheFactory", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["defaultNormalizedCacheFactory"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "RecordingCache", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["RecordingCache"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "record", function() { return apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["record"]; });

/* harmony import */ var apollo_link_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! apollo-link-http */ "./node_modules/apollo-link-http/lib/index.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "HttpLink", function() { return apollo_link_http__WEBPACK_IMPORTED_MODULE_3__["HttpLink"]; });

/* harmony import */ var apollo_link_state__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! apollo-link-state */ "./node_modules/apollo-link-state/lib/index.js");
/* harmony import */ var apollo_link_error__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! apollo-link-error */ "./node_modules/apollo-link-error/lib/index.js");
/* harmony import */ var graphql_tag__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! graphql-tag */ "./node_modules/graphql-tag/src/index.js");
/* harmony import */ var graphql_tag__WEBPACK_IMPORTED_MODULE_6___default = /*#__PURE__*/__webpack_require__.n(graphql_tag__WEBPACK_IMPORTED_MODULE_6__);
/* harmony reexport (default from non-harmony) */ __webpack_require__.d(__webpack_exports__, "gql", function() { return graphql_tag__WEBPACK_IMPORTED_MODULE_6___default.a; });
var __extends = (undefined && undefined.__extends) || (function () {
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
var __assign = (undefined && undefined.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};











var PRESET_CONFIG_KEYS = [
    'request',
    'uri',
    'credentials',
    'headers',
    'fetch',
    'fetchOptions',
    'clientState',
    'onError',
    'cacheRedirects',
    'cache',
];
var DefaultClient = (function (_super) {
    __extends(DefaultClient, _super);
    function DefaultClient(config) {
        if (config === void 0) { config = {}; }
        var _this = this;
        if (config) {
            var diff = Object.keys(config).filter(function (key) { return PRESET_CONFIG_KEYS.indexOf(key) === -1; });
            if (diff.length > 0) {
                console.warn('ApolloBoost was initialized with unsupported options: ' +
                    ("" + diff.join(' ')));
            }
        }
        var request = config.request, uri = config.uri, credentials = config.credentials, headers = config.headers, fetch = config.fetch, fetchOptions = config.fetchOptions, clientState = config.clientState, cacheRedirects = config.cacheRedirects, errorCallback = config.onError;
        var cache = config.cache;
        if (cache && cacheRedirects) {
            throw new Error('Incompatible cache configuration. If providing `cache` then ' +
                'configure the provided instance with `cacheRedirects` instead.');
        }
        if (!cache) {
            cache = cacheRedirects
                ? new apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["InMemoryCache"]({ cacheRedirects: cacheRedirects })
                : new apollo_cache_inmemory__WEBPACK_IMPORTED_MODULE_2__["InMemoryCache"]();
        }
        var stateLink = clientState
            ? Object(apollo_link_state__WEBPACK_IMPORTED_MODULE_4__["withClientState"])(__assign({}, clientState, { cache: cache }))
            : false;
        var errorLink = errorCallback
            ? Object(apollo_link_error__WEBPACK_IMPORTED_MODULE_5__["onError"])(errorCallback)
            : Object(apollo_link_error__WEBPACK_IMPORTED_MODULE_5__["onError"])(function (_a) {
                var graphQLErrors = _a.graphQLErrors, networkError = _a.networkError;
                if (graphQLErrors) {
                    graphQLErrors.map(function (_a) {
                        var message = _a.message, locations = _a.locations, path = _a.path;
                        return console.log("[GraphQL error]: Message: " + message + ", Location: " +
                            (locations + ", Path: " + path));
                    });
                }
                if (networkError) {
                    console.log("[Network error]: " + networkError);
                }
            });
        var requestHandler = request
            ? new apollo_link__WEBPACK_IMPORTED_MODULE_1__["ApolloLink"](function (operation, forward) {
                return new apollo_link__WEBPACK_IMPORTED_MODULE_1__["Observable"](function (observer) {
                    var handle;
                    Promise.resolve(operation)
                        .then(function (oper) { return request(oper); })
                        .then(function () {
                        handle = forward(operation).subscribe({
                            next: observer.next.bind(observer),
                            error: observer.error.bind(observer),
                            complete: observer.complete.bind(observer),
                        });
                    })
                        .catch(observer.error.bind(observer));
                    return function () {
                        if (handle) {
                            handle.unsubscribe();
                        }
                    };
                });
            })
            : false;
        var httpLink = new apollo_link_http__WEBPACK_IMPORTED_MODULE_3__["HttpLink"]({
            uri: uri || '/graphql',
            fetch: fetch,
            fetchOptions: fetchOptions || {},
            credentials: credentials || 'same-origin',
            headers: headers || {},
        });
        var link = apollo_link__WEBPACK_IMPORTED_MODULE_1__["ApolloLink"].from([
            errorLink,
            requestHandler,
            stateLink,
            httpLink,
        ].filter(function (x) { return !!x; }));
        _this = _super.call(this, { cache: cache, link: link }) || this;
        return _this;
    }
    return DefaultClient;
}(apollo_client__WEBPACK_IMPORTED_MODULE_0__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (DefaultClient);
//# sourceMappingURL=index.js.map

/***/ }),

/***/ "./node_modules/apollo-link/lib/index.js":
/*!***********************************************!*\
  !*** ./node_modules/apollo-link/lib/index.js ***!
  \***********************************************/
/*! exports provided: empty, from, split, concat, ApolloLink, execute, createOperation, makePromise, toPromise, fromPromise, fromError, Observable */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _link__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./link */ "./node_modules/apollo-link/lib/link.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "empty", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["empty"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "from", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["from"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "split", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["split"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "concat", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["concat"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ApolloLink", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["ApolloLink"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "execute", function() { return _link__WEBPACK_IMPORTED_MODULE_0__["execute"]; });

/* harmony import */ var _linkUtils__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./linkUtils */ "./node_modules/apollo-link/lib/linkUtils.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "createOperation", function() { return _linkUtils__WEBPACK_IMPORTED_MODULE_1__["createOperation"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "makePromise", function() { return _linkUtils__WEBPACK_IMPORTED_MODULE_1__["makePromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "toPromise", function() { return _linkUtils__WEBPACK_IMPORTED_MODULE_1__["toPromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "fromPromise", function() { return _linkUtils__WEBPACK_IMPORTED_MODULE_1__["fromPromise"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "fromError", function() { return _linkUtils__WEBPACK_IMPORTED_MODULE_1__["fromError"]; });

/* harmony import */ var zen_observable_ts__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! zen-observable-ts */ "./node_modules/zen-observable-ts/lib/index.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "Observable", function() { return zen_observable_ts__WEBPACK_IMPORTED_MODULE_2__["default"]; });





//# sourceMappingURL=index.js.map

/***/ })

})
//# sourceMappingURL=main.d4137ca8dce4b07372b7.hot-update.js.map