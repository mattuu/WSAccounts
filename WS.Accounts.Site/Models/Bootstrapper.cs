using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Site.Models
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var container = BuildUnityContainer();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, AccountsContext>(new PerResolveLifetimeManager());

            container.RegisterType<IRepository<Account>, DbContextRepository<Account>>();
            container.RegisterType<IRepository<Transaction>, DbContextRepository<Transaction>>();
            container.RegisterType<IRepository<Product>, DbContextRepository<Product>>();

            return container;
        }
    }
}