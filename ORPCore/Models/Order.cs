using System;

namespace ORP.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public City CityFrom { get; set; }
		public City CityTo { get; set; }
		public float Price { get; set; }
		public float Duration { get; set; }
		public DateTime OrderTime { get; set; }
		public Parcel Parcel { get; set; }
    }
}