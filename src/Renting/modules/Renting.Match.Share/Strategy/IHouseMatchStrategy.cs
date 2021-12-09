using Renting.Match.Models;
using Renting.Match.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Strategy
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 11:18:08 AM
	/// @source : 
	/// @des : 房源匹配策略
	/// </summary>
	public interface IHouseMatchStrategy
    {

		/// <summary>
		/// 根据房源生成对应的求租匹配
		/// </summary>
		/// <param name="house"></param>
		/// <returns></returns>
		TenancyMatch[] GetTenancyMatches(House house);

	}
}
