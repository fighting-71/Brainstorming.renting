using Renting.Match.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:27:19 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IMatchHandler
    {
		Task<Tenancy[]> Run(House house);
    }

	public interface IChinaMatchHandler : IMatchHandler { }
	public interface IBritainMatchHandler : IMatchHandler { }

}
