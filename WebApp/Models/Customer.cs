using System.Collections.Generic;

namespace WebApp.Models
{
    public class Customer
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }
       
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        // Навігаційна властивість
        public List<Purchase> Purchases { get; set; }
    }
}
