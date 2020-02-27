using ORP.Models.Enums;

namespace ORP.Models
{
	public class Connection
	{
		public int ConnectionId { get; set; }
		public City CityOne { get; set; }
		public City CityTwo { get; set; }
		public ConnectionType ConnectionType { get; set; }
	}
}