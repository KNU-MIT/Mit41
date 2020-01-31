using System;

namespace WebApp.Models
{
    public class Purchase
    {
        // ID покупки 
        public int PurchaseId { get; set; }

        // Покупець 
        public Customer Customer { get; set; }

        // адреса покупця 
        public string Address { get; set; }

        // ID книги 
        public int BookId { get; set; }

        // дата покупки 
        public DateTime Date { get; set; }
    }
}
