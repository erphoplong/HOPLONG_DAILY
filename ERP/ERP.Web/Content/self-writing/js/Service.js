app.service('hanghoaService', function ($http) {
    this.get_hanghoa = function () {
        return $http.get('/api/Api_HangHoaDaiLy').then(function (response) {
            return response.data;
        });
    };

    this.get_tonkho = function (id) {
        return $http.get('/api/Api_TonKhoDaiLy/' + id + '/DAILY').then(function (response) {
            return response.data;
        });
    };
    this.get_quantam = function (username) {
        return $http.get("/api/Api_HangDuocQuanTamDL/" + username).then(function (response) {
            return response.data;
        });
    }
});