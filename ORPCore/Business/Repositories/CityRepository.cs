using System.Linq;
using ORPCore.Models;
using ORPCore.Models.Context;

namespace ORPCore.Business.Repositories
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