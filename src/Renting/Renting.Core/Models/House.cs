using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Models
{
	/// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:06:53 AM
	/// @source : 
	/// @des : 房源
	/// </summary>
	public class House : BaseIssuerInfo
	{

		public string[] Tags;

		public string FormData { get; set; }

		public int FormVersion { get; set; }

		public PositionInfo Position { get; set; }

	}
}
