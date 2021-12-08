using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Infrastructure.Flags
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:29:47 AM
	/// @source : 
	/// @des : 处理者标记
	/// </summary>
	public class ImplAttribute : Attribute
    {
		public Type ImplType { get; set; }

        public ImplAttribute(Type implType)
        {
            ImplType = implType;
        }
    }
}
