using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// The Home controller class.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Instantiate an instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="ApplicationDbContext"/> data base context for injection.</param>
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Controller shows the set of <see cref="Book"/>s.
        /// </summary>
        public IActionResult Index()
        {
            //отримуємо з БД всі об'єкти Book
            IEnumerable<Book> books = _dbContext.Books.ToList();

            //повертаємо відображення 
            return View(books);
        }

        /// <summary>
        /// Controller shows the form for creating a new <see cref="Book"/>.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Controller receives a new <see cref="Book"/> instance and adds it to data base.
        /// </summary>
        /// <param name="book">The new instance.</param>
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (book != null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Buy(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == Id.Value);

            if (book != null)
            {
                return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(Purchase purchase)
        {
            if (purchase == null)
            {
                return BadRequest();
            }

            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == purchase.CustomerId);

            if(customer==null)
            {
                return BadRequest();
            }

            purchase.Customer = customer;
            purchase.Date = DateTime.Now;

            purchase.Id = null;

            //додаємо інформацію про купівлю в БД
            _dbContext.Purchases.Add(purchase);
            //зберігаємо у БД всі зміни
            _dbContext.SaveChanges();



            return View($"Дякуємо, {customer.FirstName} {customer.LastName}, за купівлю!");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Book book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    return View(book);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _dbContext.Update(book);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
