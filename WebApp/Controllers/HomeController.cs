﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;
using System.Linq;
using System;

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

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(book !=null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Buy(int? Id)
        {
            ViewBag.BookId = Id ?? 0;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;

            //додаємо інформацію про купівлю в БД
            _dbContext.Purchases.Add(purchase);
            //зберігаємо у БД всі зміни
            _dbContext.SaveChanges();

            return $"Дякуємо, {purchase.Customer.FirstName} {purchase.Customer.LastName}, за купівлю!";
        }

        public IActionResult Edit(int? id)
        {
            if(id!=null)
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
