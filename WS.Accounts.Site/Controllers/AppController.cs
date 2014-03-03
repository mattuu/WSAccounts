using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Site.Controllers
{
    [BreezeController]
    public class AppController : ApiController
    {
        private readonly EFContextProvider<AccountsContext> _contextProvider;

        public AppController(EFContextProvider<AccountsContext> contextProvider )
        {
            if (contextProvider == null) throw new ArgumentNullException("contextProvider");
            _contextProvider = contextProvider;
        }

        [HttpGet]
        public String Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Account> Accounts()
        {
            return _contextProvider.Context.Accounts;
        }
    }
}