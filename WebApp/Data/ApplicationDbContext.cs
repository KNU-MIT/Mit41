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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Purchase>()
                .HasOne<Book>(purchase => purchase.Book)
                .WithMany(book => book.Purchases)
                .HasForeignKey(purchase => purchase.BookId);


            // відношення "один-до-багатьох"
            builder.Entity<Customer>() // сутність, що підлягає налаштуванню
                .HasMany<Purchase>(customer => customer.Purchases) // головний клас Customer містить колекцію підпорядкованих об'єктів Purchases
            .WithOne(purchase => purchase.Customer) // кожен такий підпорядкований об'єкт Purchases пов'язаний з одним головним об'єктом Customer
            .HasForeignKey(purchase => purchase.CustomerId); // у реляційних БД для таблиці Purchases створюється зовнішній ключ, де Purchase.CustomerId == Customer.Id

            //// те ж саме відношення "один-до-багатьох", але описане по-іншому
            //builder.Entity<Purchase>()
            //    .HasOne<Customer>(purchase => purchase.Customer)
            //    .WithMany(customer => customer.Purchases)
            //    .HasForeignKey(purchase=>purchase.CustomerId);
        }
    }
}






//Books.Add(new Book { Name = "Совершенный код", Author = "Стив Макконнелл", Price = 660 });
//            Books.Add(new Book { Name = "Паттерны проектирования на платформе .NET", Author = "Тепляков Сергей", Price = 316 });
//            Books.Add(new Book { Name = "ASP.NET MVC 4 с примерами на C# 5.0 для профессионалов", Author = "Адам Фримен", Price = 348 });