using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Models.Dto
{
	/// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 11:02:27 AM
	/// @source : 
	/// @des : 求租匹配
	/// </summary>
	public class TenancyMatch
    {
		public long BasicSearchKey { get; set; }
		public int MinRentByMonth { get; set; }
		public int MaxRentByMonth { get; set; }
		public double MaxDistance { get; set; }
	}
}
