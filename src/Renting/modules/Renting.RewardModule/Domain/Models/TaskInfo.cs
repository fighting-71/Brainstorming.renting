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
	/// @since : 12/8/2021 2:28:09 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class TaskInfo
    {
		public Guid Id { get; set; }
		public TaskType TaskType { get; set; }
		public TaskModule TaskModule { get; set; }
		public ActionType AttentionAction { get; set; }
		public int[] SubActionTypes { get; set; }
		public DateTime? MaxValidTime { get; set; }
		public bool IsEnable { get; set; }
		public string DisplayFlag { get; set; }
		public int? DailyCompletedCount { get; set; }
		public int MaxCompletedCount { get; set; }
        public LimitType LimitType { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Remark { get; set; }
		public string Tags { get; set; }
		public int RewardCount { get; set; }
		public decimal? MaxDiff { get; set; }
		public decimal? MaxRange { get; set; }
    }
}
