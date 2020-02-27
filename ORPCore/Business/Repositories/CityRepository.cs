using System.Linq;
using ORP.Models;
using ORP.Models.Context;

namespace ORP.Business.Repositories
{
	public class CityRepository
	{

		public City GetCity(string cityName)
		{
            using (var context = new OrpContext())
            {
                return context.Cities.FirstOrDefault(x => x.Name == cityName);
            }
		}
	}
}