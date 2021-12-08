using Renting.Match.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Models
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:13:20 AM
	/// @source : 
	/// @des : 位置信息
	/// </summary>
	public class PositionInfo
    {
        public Country Country { get; set; }
        public ChinaCity City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
    }

    /// <summary>
    /// 地理定位
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 获取距离差值
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetDistance(Location other)
        {
            throw new NotImplementedException();
        }
    }

}
