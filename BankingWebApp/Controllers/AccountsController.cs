using BankingWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private BankingDbContext db;
        public AccountsController(BankingDbContext db) {
            this.db = db;
        }
        public IActionResult Index()
        {
            var accounts = db.Accounts;
            return View(accounts);
        }
    }
}
