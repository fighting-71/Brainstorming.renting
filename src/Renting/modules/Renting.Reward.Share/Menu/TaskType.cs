using Renting.Reward.Domain.Handlers;
using Renting.Infrastructure.Flags;

namespace Renting.Reward.Domain.Menu
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:29:18 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public enum TaskType
    {
		[Impl(typeof(ITriggerTaskCompleteHandler))]
		Trigger,
		[Impl(typeof(IDiffTaskCompleteHandler))]
		Diff,
		[Impl(typeof(IRangeTaskCompleteHandler))]
		Range,
		[Impl(typeof(INoCheckTaskCompleteHandler))]
		Job,
		[Impl(typeof(INoCheckTaskCompleteHandler))]
		Sepcial
    }
}
