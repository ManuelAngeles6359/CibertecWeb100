(function () {
    'use strict';
    angular.module('app')
        .directive('orderItemCard', orderItemCard);
    function orderItemCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                id: '@',
                orderId: '@',
                productId: '@',
                unitPrice: '@',
                quantity: '@'
            },
            templateUrl: 'app/private/orderItem/directives/orderItem-card/order-item-card.html'

        };
    }
})();
