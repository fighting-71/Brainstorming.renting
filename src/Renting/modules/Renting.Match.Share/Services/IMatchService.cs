using Renting.Match.Share.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match.Share.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/9/2021 10:32:11 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IMatchCheckService
    {
		Task<UserMatchCheckResult> UserCheckAsync(Guid needer, Guid supplier);
		Task<bool> IdentityCheckAsync(Guid needer, Guid supplier);

    }
}
