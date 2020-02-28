using System.Collections.Generic;
using System.Linq;

namespace ORPCore.Models
{
	public class GraphNode
	{
		public readonly City City;
		public ConnectionData ConnectionData { get; set; }
		public GraphNode CameFrom { get; set; }
		public List<float> ExtraCost { get; set; }
		public float ScaledPrice { get; set; }

		public GraphNode(City city, GraphNode cameFrom, ConnectionData connectionData)
		{
			CameFrom = cameFrom;
			City = city;
			ConnectionData = connectionData;
			SetupExtraCost();
			ScaledPrice = connectionData.Price + (ExtraCost?.Sum(x => x * connectionData.Price) ?? 0);
		}

		private void SetupExtraCost()
		{
			ExtraCost = new List<float>();
			if (CameFrom != null && CameFrom.ExtraCost.Count > 0)
				ExtraCost.AddRange(CameFrom.ExtraCost);
			if (City.PricePenalty > 0)
				ExtraCost.Add(City.PricePenalty);
		}
	}
}
