using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}






//Books.Add(new Book { Name = "Совершенный код", Author = "Стив Макконнелл", Price = 660 });
//            Books.Add(new Book { Name = "Паттерны проектирования на платформе .NET", Author = "Тепляков Сергей", Price = 316 });
//            Books.Add(new Book { Name = "ASP.NET MVC 4 с примерами на C# 5.0 для профессионалов", Author = "Адам Фримен", Price = 348 });