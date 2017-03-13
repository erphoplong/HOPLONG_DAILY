app.controller('hanghoaCtrl', function (hanghoaService, $scope) {
    $scope.loadHangHoa = function () {
        hanghoaService.get_hanghoa().then(function (d) {
            $scope.danhsachhanghoa = d;
        });
    };
    $scope.loadHangHoa();

    $scope.edit = function (item) {
        $scope.item = item;
        var donggoivalue = $('.' + item.MA_HANG + '-1').html();

        var thongsovalue = $('.' + item.MA_HANG + '-2').html();

    }

    $scope.get_tonkho = function (id) {
        hanghoaService.get_tonkho(id).then(function (a) {
            $scope.danhsachtonkho = a;
        });
    };

    $scope.getTotal = function (type) {
        var total = 0;
        angular.forEach($scope.danhsachtonkho, function (el) {
            total += el[type];
        });
        return total;
    };

    $scope.loadQuanTam = function () {
        var quantam = $('#userquantam').val();
        hanghoaService.get_quantam(quantam).then(function (z) {
            $scope.danhsachquantam = z;
        });
    }
    $scope.loadQuanTam();
});
app.filter('unsafe', function ($sce) { return $sce.trustAsHtml; });