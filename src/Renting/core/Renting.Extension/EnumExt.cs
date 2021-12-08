using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Command.Extension
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:32:01 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public static class EnumExt
    {

		public static T GetAttr<T>(this Enum menu) where T : Attribute
        {
            Type type = menu.GetType();
            FieldInfo fd = type.GetField(menu.ToString());
            return fd.CustomAttributes.FirstOrDefault(x => x is T) as T;
        }

    }
}
