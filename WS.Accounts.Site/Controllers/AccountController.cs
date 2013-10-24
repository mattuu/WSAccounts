using System.Linq;
using System.Web.Mvc;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Site.Controllers
{
    public class AccountController : Controller
    {
        private IRepository<Account> _repository;
        //
        // GET: /Account/
        public AccountController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository);
        }

        public ActionResult Create(Account account)
        {
            if (account.AccountId != 0)
            {
                _repository.Add(account);
                _repository.Submit();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.FirstOrDefault(a => a.AccountId == id));
        }

        public ActionResult Delete(int id)
        {
            var item = _repository.FirstOrDefault(a => a.AccountId == id);
            _repository.Delete(item);
            _repository.Submit();
            return RedirectToAction("Index");
        }
    }
}
