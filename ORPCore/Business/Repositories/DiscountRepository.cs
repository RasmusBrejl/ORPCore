using System.Linq;
using ORPCore.Models;
using ORPCore.Models.Context;

namespace ORPCore.Business.Repositories
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