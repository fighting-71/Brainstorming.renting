using Renting.Reward.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Reward.Domain.Models
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:21:03 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class ActionInfo
    {
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public ActionType ActionType { get; set; }
		public int SubType { get; set; }
		public DateTime CreateTime { get; set; }
    }
}
