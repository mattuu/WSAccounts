using System.Data.Entity;
using Breeze.ContextProvider.EF6;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Site
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, AccountsContext>(new PerResolveLifetimeManager(), new InjectionConstructor("WSAccounts"));

            new EFContextProvider<AccountsContext>();

            //container.RegisterType<IRepository<Account>, 

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}