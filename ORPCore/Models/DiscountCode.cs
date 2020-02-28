using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORP.Models
{
    public class DiscountCode
    {
        public int DiscountCodeId { get; set; }
        public string Code { get; set; }
        public float Discount { get; set; }
    }
}
