/// <reference path="../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../Scripts/typings/q/Q.d.ts" />
/// <reference path="../Scripts/typings/breeze/breeze.d.ts" />
/// <reference path="../Scripts/typings/knockout/knockout.d.ts" />
module WS.Accounts {

    export class homeViewModel {

        accounts: KnockoutObservableArray<any>;

        constructor() {
            var manager = new breeze.EntityManager('breeze/app');

            var eq = new breeze.EntityQuery("Accounts");

            manager.executeQuery(eq).then(d=> {
                $.each(d, function(i, item) {
                    this.accounts.push(item);
                });

            });
        }
    }
}