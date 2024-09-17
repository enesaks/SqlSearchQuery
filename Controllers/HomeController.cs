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
                    ? await _context.Companies.ToListAsync()
                    : await _context.Companies.Where(x => x.Segment == segment).ToListAsync();
            }
            else
            {
                // Eğer segmentTxt doluysa, onunla sorgula
                companies = await _context.Companies.Where(x => x.Segment == segmentTxt).ToListAsync();

                // Eğer sonuç bulunamazsa, alternatif sorgu yap
                if (!companies.Any())
                {
                    companies = string.IsNullOrEmpty(segment)
                        ? await _context.Companies.ToListAsync()
                        : await _context.Companies.Where(x => x.Segment == segment).ToListAsync();
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
    }
}
