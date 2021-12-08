using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Infrastructure.MQModule
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:13:32 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class NewActionMessage : BaseMessage
    {
		public Guid ActionId { get; set; }
    }
}
