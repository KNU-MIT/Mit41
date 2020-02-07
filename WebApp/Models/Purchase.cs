using System;

namespace WebApp.Models
{
    public class Purchase
    {
        // ID покупки 
        public int? Id { get; set; }

        // дата покупки 
        public DateTime Date { get; set; }



        // Зовнішній ключ 
        public int BookId { get; set; }
        // Навігаційна властивість
        public Book Book { get; set; }


        // Зовнішній ключ
        public int CustomerId { get; set; }
        // Навігаційна властивість
        public Customer Customer { get; set; }
    }
}
