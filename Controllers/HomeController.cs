using Microsoft.AspNetCore.Mvc;
using SqlSearchQuery.Models.Context;
using SqlSearchQuery.Models;
using Microsoft.EntityFrameworkCore;
using SqlSearchQuery.Models.Entities;

namespace SqlSearchQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlSearchQueryContext _context;

        public HomeController(SqlSearchQueryContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            // TempData'dan segmentleri al
            string segment = TempData["Segment"] as string;
            string segmentTxt = TempData["SegmentTxt"] as string;

            List<Company> companies;

            // Segment ve segmentTxt değerlerini kontrol et
            if (string.IsNullOrEmpty(segmentTxt))
            {
                // Eğer segmentTxt boşsa, segment'e göre sorgula
                companies = string.IsNullOrEmpty(segment)
                    ? await _context.Companies.Where(x => x.IsDelete == false).ToListAsync()
                    : await _context.Companies.Where(x => x.Segment == segment && x.IsDelete == false).ToListAsync();
            }
            else
            {
                // Eğer segmentTxt doluysa, onunla sorgula
                companies = await _context.Companies.Where(x => x.Segment == segmentTxt && x.IsDelete == false).ToListAsync();

                // Eğer sonuç bulunamazsa, alternatif sorgu yap
                if (!companies.Any())
                {
                    companies = string.IsNullOrEmpty(segment)
                        ? await _context.Companies.ToListAsync()
                        : await _context.Companies.Where(x => x.Segment == segment && x.IsDelete == false).ToListAsync();
                }
            }

            var segments = await _context.Companies.Select(c => c.Segment).Distinct().ToListAsync();

            // ViewModel'i doldur
            var viewModel = new HomeViewModel
            {
                Companies = companies,
                Segments = segments
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SegmentPost(IFormCollection data)
        {
            string selectedSegment = data["SegmentSelect"].ToString();
            string segmentText = data["SegmentText"].ToString();

            // TempData'ya değerleri kaydet
            TempData["Segment"] = selectedSegment;
            TempData["SegmentTxt"] = segmentText;

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCompany(int id)
        {
            var deleteCompany = _context.Companies.Find(id);

            if (deleteCompany == null)
            {
                // Eğer şirket bulunmazsa, bir hata sayfasına yönlendirebilir veya bir mesaj gösterebilirsin.
                return NotFound();
            }

            System.Console.WriteLine("id : " + id);

            deleteCompany.IsDelete = true;
            deleteCompany.DeleteTime = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GarbageIndex()
        {
            var values = _context.Companies.Where(x => x.IsDelete == true).ToList();

            return View(values);
        }

        public IActionResult outGarbage(int id)
        {
            var outCompany = _context.Companies.Find(id);

            if (outCompany == null)
            {
                // Eğer şirket bulunmazsa, bir hata sayfasına yönlendirebilir veya bir mesaj gösterebilirsin.
                return NotFound();
            }

            System.Console.WriteLine("id : " + id);

            outCompany.IsDelete = false;
            outCompany.DeleteTime = null;
            _context.SaveChanges();

            return RedirectToAction("GarbageIndex");
        }

        public async Task<IActionResult> DeleteForever()
        {
            var DeleteList = _context.Companies.Where(x => x.IsDelete == true);
            DateTime now = DateTime.Now;

            foreach (var item in DeleteList)
            {
                System.Console.WriteLine(item.CompanyId);
                if (item.DeleteTime != null && (now - item.DeleteTime.Value).TotalDays >= 7)//7 gün veya daha fazla çöp kovasında ise silinecek.
                {
                    _context.Companies.Remove(item);
                    //_context.SaveChanges();
                }
            }

            return Ok();
        }

    }
}
