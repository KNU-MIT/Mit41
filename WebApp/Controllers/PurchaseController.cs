using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var purchases = await _dbContext  // Контекст даних
                .Purchases // підпорядковані дані 
                .Include(p => p.Book) // пов'язані (через навігаційну властивість) дані з головної таблиці
                .Include(p => p.Customer) // пов'язані (через навігаційну властивість) дані з головної таблиці
                .ToListAsync(); // отримання колекції даних

            return View(purchases);
        }
    }
}