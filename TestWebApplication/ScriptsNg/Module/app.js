﻿var app;
(function () {
    'use strict'; //Defines that JavaScript code should be executed in "strict mode"
    app = angular.module('app', [
        'ui.bootstrap',
        'smart-table',
        'mw-datepicker-range',
        'pascalprecht.translate'
    ]);
})();