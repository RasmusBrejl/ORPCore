using ORP.Models.Enums;
using ORPCore.Models;

namespace ORP.Models
{
	public class Connection
	{
		public int ConnectionId { get; set; }
		public string CityOne { get; set; }
		public string CityTwo { get; set; }
		public ConnectionType ConnectionType { get; set; }
	}
}