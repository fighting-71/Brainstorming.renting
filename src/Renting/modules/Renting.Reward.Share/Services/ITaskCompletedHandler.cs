using Renting.Reward.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Reward.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 3:08:23 PM
	/// @source : 
	/// @des : 任务完成处理器
	/// </summary>
	public interface ITaskCompletedHandler
    {
		public Task RunAsync(TaskCompleteDto taskCompleteDto);
	}
}
