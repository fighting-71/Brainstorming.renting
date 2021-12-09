using Renting.Match.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match.Share.Handlers
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/9/2021 11:12:12 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IMatchHandler
    {
    }

    public interface ICommonMatchHandler : IMatchHandler
    {
        Task Run(House house, Tenancy tenancy);
    }
    public interface INewHouseMatchHandler : IMatchHandler
    {
        Task Run(Guid houseId);
    }

}
