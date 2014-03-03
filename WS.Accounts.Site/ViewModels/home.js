define(["require", "exports"], function(require, exports) {
    var homeViewModel = (function () {
        function homeViewModel() {
            var manager = new breeze.EntityManager('breeze/app');

            var query = manager.EntityQuery().from("Accounts");

            manager.executeQuery(query).then(function (d) {
                return accounts(d);
            });
        }
        return homeViewModel;
    })();
    exports.homeViewModel = homeViewModel;
});
//# sourceMappingURL=home.js.map
