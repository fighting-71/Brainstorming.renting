using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Infrastructure.MQModule.Flags
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:15:41 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class SubscriptionAttribute : Attribute
    {

		public string SubscriptionId { get; set; }

        public SubscriptionAttribute(string subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
