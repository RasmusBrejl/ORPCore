using System.Linq;
using ORP.Models;
using ORP.Models.Context;

namespace ORP.Business.Repositories
{
	public class ConnectionRepository
	{
		public Connection GetConnection(City cityFrom, City cityTo)
		{
            using (var context = new OrpContext())
            {
                return context.Connections.FirstOrDefault(x => x.CityOne == cityFrom.Name && x.CityTwo == cityTo.Name);
            }
		}
	}
}