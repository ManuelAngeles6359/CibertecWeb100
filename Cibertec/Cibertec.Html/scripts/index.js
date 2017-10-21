(function (cibertec) {
    cibertec.Index = {
        currentYear: function () {
            var today = new Date();
            return today.getUTCFullYear();
        }
    };
    document.getElementById("date").innerHTML = cibertec.Index.currentYear();
})(window.cibertec = window.cibertec || {});