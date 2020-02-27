namespace ORPCore.Models
{
	public class City
	{
		public int CityId { get; set; }
		public string Name { get; set; }
		public int NumberOfHits { get; set; }

        public bool Valid { get; set; }

        public float PricePenalty { get; set; }
    }
}