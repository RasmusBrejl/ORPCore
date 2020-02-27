using System.Collections.Generic;
using ORP.Models.Enums;

namespace ORP.Models
{
	public class Parcel
	{
		public int ParcelId { get; set; }
		public float Weight { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }
		public float Length { get; set; }
		public List<ParcelType> ParcelTypes { get; set; }
	}
}