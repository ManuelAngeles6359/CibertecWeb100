(function () {
    angular
        .module('app')
        .factory('dataService', dataService);

    dataService.$inject = ['$http'];

    function dataService($http) {
        var service = {};
        service.getData = getData;
        service.postData = postData;
        service.putData = putData;
        service.deleteData = deleteData;

        return service;

        function getData(url) {
            return $http.get(url)
        }
        function postData(url) {
            return $http.post(url)
        }
        function putData(url) {
            return $http.put(url)
        }
        function deleteData(url) {
            return $http.delete(url)
        }

    }
})();