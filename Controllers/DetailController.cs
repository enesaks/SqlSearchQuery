using Microsoft.AspNetCore.Mvc;
using SqlSearchQuery.Models.Context;

namespace SqlSearchQuery.Controllers
{
    public class DetailController : Controller
    {
        SqlSearchQueryContext _context;

        public DetailController(SqlSearchQueryContext context)
        {
            _context = context;
        }

        // GET: DetailController
        public ActionResult Index(int id)
        {
            var value = _context.Companies.Find(id);
            return View(value);
        }

    }
}
