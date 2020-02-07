using System.Collections.Generic;

namespace WebApp.Models
{
    public class Book
    {
        // ID книги 
        public int? Id { get; set; }

        //назва книги
        public string Name { get; set; }

        // автор книги 
        public string Author { get; set; }

        // цiна 
        public double Price { get; set; }

        // Навігаційна властивість
        public List<Purchase> Purchases { get; set; }
    }
}
