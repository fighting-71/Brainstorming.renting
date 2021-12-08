using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Models
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:07:00 AM
	/// @source : 
	/// @des : 求租
	/// </summary>
	public class Tenancy : BaseIssuerInfo
	{
		public PositionInfo[] Positions { get; set; }
		public string Voice { get; set; }
	}
}
