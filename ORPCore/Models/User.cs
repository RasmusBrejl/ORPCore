using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORP.Models
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