using System;
using Newtonsoft.Json;

namespace ORPCore.Models
{
	public class RequestRouteObject
	{
		[JsonProperty("city_from")] public string city_from { get; set; }

		[JsonProperty("city_to")] public string city_to { get; set; }

		[JsonProperty("weight")] public float weight { get; set; }

		[JsonProperty("width")] public float width { get; set; }

		[JsonProperty("height")] public float height { get; set; }

		[JsonProperty("length")] public float length { get; set; }

		[JsonProperty("cold")] public bool cold { get; set; }

		[JsonProperty("fragile")] public bool fragile { get; set; }

		[JsonProperty("animals")] public bool animals { get; set; }

		[JsonProperty("weapons")] public bool weapons { get; set; }

		[JsonProperty("recommended_delivery")] public bool recommended_delivery { get; set; }

		[JsonProperty("date")] public DateTime date { get; set; }
	}
}