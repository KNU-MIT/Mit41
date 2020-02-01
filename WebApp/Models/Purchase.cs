using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class Purchase
    {
        // ID покупки 
        public int PurchaseId { get; set; }

        // Покупець
        public int CustomerId { get; set; }

        // адреса покупця 
        public string Address { get; set; }

        // ID книги 
        public int BookId { get; set; }

        // дата покупки 
        public DateTime Date { get; set; }
    }
}
