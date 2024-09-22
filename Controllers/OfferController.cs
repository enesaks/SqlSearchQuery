using Microsoft.AspNetCore.Mvc;
using SqlSearchQuery.BackroundServices;
using SqlSearchQuery.Models;
using SqlSearchQuery.Models.Context;
using SqlSearchQuery.Models.Entities;

namespace SqlSearchQuery.Controllers
{
    public class OfferController : Controller
    {
        // GET: OfferController
        private readonly SqlSearchQueryContext _context;

        private readonly IEmailSender _emailSender;
        public OfferController(SqlSearchQueryContext context, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _context = context;
        }


        public ActionResult Index(int id)
        {
            var company = _context.Companies.Find(id);
            ViewBag.companyName = company.CompanyName;
            ViewBag.companyEmail = company.EmailAddress;
            ViewBag.companyId = company.CompanyId;

            ViewBag.OfferTime = DateTime.Now;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OfferPost(Offer offer)
        {
            string companyMail = offer.CompanyEmail;
            string offerMail = offer.Email;
            string title = offer.JobTittle;
            string message = offer.JobComment;
            string namesurname = offer.NameSurname;
            string companyName = offer.CompanyName;

            System.Console.WriteLine($"şirket postası :{companyMail}");

            await _emailSender.SendEmailAsync(companyMail, companyName, offerMail, title, message, namesurname);

            _context.Offers.Add(offer);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");

        }


    }
}
