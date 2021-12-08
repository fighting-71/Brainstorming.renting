using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Flags
{
	/// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 1:55:31 PM
	/// @source : 
	/// @des : 距离限制标记
	/// </summary>
	public class DistanceLimitAttribute : Attribute
    {
		/// <summary>
		/// 默认
		/// </summary>
		public double Default { get; set; }
		/// <summary>
		/// 主页
		/// </summary>
		public double Home { get; set; }
		/// <summary>
		/// 收费版
		/// </summary>
		public double Vip { get; set; }
    }
}
