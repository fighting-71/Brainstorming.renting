using Renting.Match.Flags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Menu
{
	/// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:23:29 AM
	/// @source : 
	/// @des : 中国城市
	/// </summary>
	public enum ChinaCity
    {
		[DistanceLimit(Default = 1, Home = 2, Vip = 3.5)]
		BeiJing,
		[DistanceLimit(Default = 2, Home = 3, Vip = 4)]
		ShangHai,

    }
}
