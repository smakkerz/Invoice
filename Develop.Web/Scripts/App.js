var invoice = angular.module('AppInvoice', []);

invoice.filter('rupiah', function () {
    return function toRp(angka) {
        var rev = parseInt(angka, 10).toString().split('').reverse().join('');
        var rev2 = '';
        for (var i = 0; i < rev.length; i++) {
            rev2 += rev[i];
            if ((i + 1) % 3 === 0 && i !== (rev.length - 1)) {
                rev2 += '.';
            }
        }
        return 'Rp. ' + rev2.split('').reverse().join('') + ',00 ';
    }
});

invoice.controller('MainController', function ($scope, $http, $location, $window) {
    $scope.invoice = {
        items: [{
            product: 'item',
            qty: 1,
            price: 0
        }]
    };
    $scope.add = function () {
        $scope.invoice.items.push({
            product: '',
            qty: 1,
            price: 0
        });
    },
    $scope.remove = function (index) {
        $scope.invoice.items.splice(index, 1);
    },
    $scope.total = function () {
        var total = 0;
        angular.forEach($scope.invoice.items, function (item) {
            total += item.qty * item.price;
        })
        return total;
        }
});