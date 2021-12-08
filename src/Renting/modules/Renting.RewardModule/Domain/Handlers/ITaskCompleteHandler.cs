using Renting.Reward.Domain.Dto;
using Renting.Reward.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Reward.Domain.Handlers
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:52:39 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface ITaskCompleteHandler
    {
		Task<List<TaskCompleteDto>> RunAsync(TaskInfo taskInfo, ActionInfo actionInfo);
    }
	/// <summary>
	/// 简单次数触发
	/// </summary>
	public interface ITriggerTaskCompleteHandler : ITaskCompleteHandler { }
	/// <summary>
	/// 差值触发
	/// </summary>
	public interface IDiffTaskCompleteHandler : ITaskCompleteHandler { }
	/// <summary>
	/// 范围差触发
	/// </summary>
	public interface IRangeTaskCompleteHandler : ITaskCompleteHandler { }
	/// <summary>
	/// 无需检查的触发
	/// </summary>
	public interface INoCheckTaskCompleteHandler : ITaskCompleteHandler { }
}
