using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORPCore.Models
{
	public class Parcel
	{
		public int ParcelId { get; set; }
		public float Weight { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }
		public float Length { get; set; }
		[NotMapped]
		public List<int> ParcelTypes { get; set; }
	}
}