using Renting.Infrastructure.MQModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Reward
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:07:38 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IMQSubscribe<T> where T: BaseMessage
	{
		Task HandlerAsync(T message);
    }
}
