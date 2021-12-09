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
	/// @des : 奖励相关
	/// </summary>
	public interface IRewardService
    {
		/// <summary>
		/// 通过id获取有效的操作记录
		/// </summary>
		/// <param name="actionId"></param>
		/// <returns></returns>
		Task<ActionInfo> GetActionAsync(Guid actionId);

		/// <summary>
		/// 通过操作记录获取对应的任务
		/// </summary>
		/// <param name="actionInfo"></param>
		/// <returns></returns>
		Task<TaskInfo[]> GetTasksAsync(ActionInfo actionInfo);

    }
}
