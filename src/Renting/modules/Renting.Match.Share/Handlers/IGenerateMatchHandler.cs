using Renting.Match.Models;
using Renting.Match.Share.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match.Share.Handlers
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/9/2021 10:36:30 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IGenerateMatchHandler
    {
    }

	public interface IMatchSuccessHandler : IGenerateMatchHandler
	{
		Task RunAsync(House house, Tenancy tenancy, MatchChannel channel);
	}

	public interface IMatchInvalidHandler : IGenerateMatchHandler
	{
		Task RunAsync(House house, Tenancy tenancy, MatchInvalidType matchInvalidType, string remark);
	}
	public interface IMatchPrepareHandler : IGenerateMatchHandler
	{
		Task RunAsync(House house, Tenancy tenancy, MatchPrepareType type);
	}

}
