using Renting.Reward.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Reward.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:27:23 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IRewardService
    {

		Task<ActionInfo> GetActionAsync(Guid actionId);

		Task<TaskInfo[]> GetTasksAsync(ActionInfo actionInfo);

    }
}
