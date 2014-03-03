var WS;
(function (WS) {
    /// <reference path="../Scripts/typings/jquery/jquery.d.ts" />
    /// <reference path="../Scripts/typings/q/Q.d.ts" />
    /// <reference path="../Scripts/typings/breeze/breeze.d.ts" />
    /// <reference path="../Scripts/typings/knockout/knockout.d.ts" />
    (function (Accounts) {
        var homeViewModel = (function () {
            function homeViewModel() {
                var manager = new breeze.EntityManager('breeze/app');

                var eq = new breeze.EntityQuery("Accounts");

                manager.executeQuery(eq).then(function (d) {
                    $.each(d, function (i, item) {
                        this.accounts.push(item);
                    });
                });
            }
            return homeViewModel;
        })();
        Accounts.homeViewModel = homeViewModel;
    })(WS.Accounts || (WS.Accounts = {}));
    var Accounts = WS.Accounts;
})(WS || (WS = {}));
//# sourceMappingURL=homeViewModel.js.map
