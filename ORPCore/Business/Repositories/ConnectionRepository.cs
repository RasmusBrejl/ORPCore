using System.Collections.Generic;
using System.Linq;
using ORPCore.Models;
using ORPCore.Models.Context;

namespace ORPCore.Business.Repositories
{
	public class ConnectionRepository
	{
		public Connection GetConnection(City cityFrom, City cityTo)
		{
            using (var context = new OrpContext())
            {
                return context.Connections.FirstOrDefault(x => (x.CityOne == cityFrom.Name && x.CityTwo == cityTo.Name) || (x.CityTwo == cityFrom.Name && x.CityOne == cityTo.Name));
            }
		}

		public List<Connection> GetConnections(City city)
		{
			using (var context = new OrpContext())
			{
				return context.Connections.Where(c => c.CityOne == city.Name || c.CityTwo == city.Name).ToList();
			}
		}
	}
}