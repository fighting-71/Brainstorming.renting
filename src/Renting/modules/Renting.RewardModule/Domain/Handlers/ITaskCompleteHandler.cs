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
	public interface ITriggerTaskCompleteHandler : ITaskCompleteHandler { }
	public interface IDiffTaskCompleteHandler : ITaskCompleteHandler { }
	public interface IRangeTaskCompleteHandler : ITaskCompleteHandler { }
	public interface INoCheckTaskCompleteHandler : ITaskCompleteHandler { }
}
