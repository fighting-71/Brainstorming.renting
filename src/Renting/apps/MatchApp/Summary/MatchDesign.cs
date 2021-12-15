using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApp.Summary
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/13/2021 4:16:02 PM
	/// @source : 
	/// @des : 
	/// </summary>
	public class MatchDesign
    {
		/// <summary>
		/// 匹配的目标物
		/// </summary>
		public abstract class Target : SomeThing { }

		/// <summary>
		/// 匹配的来源
		/// </summary>
		public abstract class Other : SomeThing 
		{
			public abstract IEnumerable<SomeThing> GetMatchs();
		}

	}


}
