using Renting.Match.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Models
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:07:53 AM
	/// @source : 
	/// @des : 主体基本信息
	/// </summary>
	public class BaseIssuerInfo
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public int RentByMonth { get; set; }
        public int Rent { get; set; }
        public int EachRent { get; set; }
        public HouseType HouseType { get; set; }
        public RentType RentType { get; set; }
        public int Room { get; set; }
        public int BathRoom { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 检索key
        /// </summary>
        public long BasicSearchKey { get; set; }

    }
}
