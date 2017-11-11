﻿(function () {
    'use strict';

    angular.module('app').controller('loginController', loginController);

    loginController.$inject = ['$http', '$state', 'localStorageService', 'configService','authenticationService'];



    function loginController($http, $state, localStorageService, configService, authenticationService) {

        var vm = this;
        vm.user = {};
        vm.title = 'Login';
        vm.login = login;

        init();

        function init() {

            if (configService.setLogin()) $state.go("home");
            authenticationService.logout();

        }

        function login() {
            authenticationService.login(vm.user);
        }



    }

})();