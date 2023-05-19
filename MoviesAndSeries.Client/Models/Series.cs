using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaSMAUI.Models
{
	public struct Series
	{
		public string Name { get; set; }

		public string? Description { get; set; }

		public double Rating { get; set; }

		public int NumberOfSeasons { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Uri Poster { get; set; }

		public uint WatchCounter { get; set; }
	}
}
