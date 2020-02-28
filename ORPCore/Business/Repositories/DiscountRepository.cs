using System.Collections.Generic;
using System.Linq;
using ORP.Models;
using ORP.Models.Context;
using ORPCore.Models;

namespace ORP.Business.Repositories
{
	public class DiscountRepository
	{

		public DiscountCode GetDiscount(string discountCode)
		{
            using (var context = new OrpContext())
            {
                return context.DiscountCodes.FirstOrDefault(x => x.Code == discountCode);
            }
		}
	}
}