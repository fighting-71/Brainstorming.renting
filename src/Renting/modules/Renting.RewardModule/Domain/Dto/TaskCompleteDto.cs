using Renting.Infrastructure.MQModule.Messages;
using Renting.Reward.Domain.Models;

namespace Renting.Reward.Domain.Dto
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:58:37 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class TaskCompleteDto
    {
		public TaskCompletedInfo TaskCompletedInfo { get; set; }
		public TaskInfo TaskInfo { get; set; }
		public ActionInfo ActionInfo { get; set; }
		public RewardMessage RewardMessage { get; set; }

	}
}
