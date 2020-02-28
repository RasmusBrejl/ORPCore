using System.Collections.Generic;

namespace ORPCore.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Clearance Clearance { get; set; }

        public List<Order> Orders { get; set; }
    }
}