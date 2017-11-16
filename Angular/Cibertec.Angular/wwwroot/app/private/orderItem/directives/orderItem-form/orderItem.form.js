(function () {
    'use strict';
    angular.module('app')
        .directive('orderItemForm', orderItemForm);
    function orderItemForm() {
        return {
            restrict: 'E',
            scope: {
                orderItem: '='
            },
            templateUrl: 'app/private/orderItem/directives/orderItem-form/order-item-form.html'
        };
    }
})();