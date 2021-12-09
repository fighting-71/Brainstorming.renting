using Renting.Match.Share.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Share.Dto
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/9/2021 10:42:43 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public struct UserMatchCheckResult
    {
        public bool IsMatch { get; set; }
        public MatchInvalidType? MatchInvalidType { get; set; }
        public string InvalidReson { get; set; }
    }
}
