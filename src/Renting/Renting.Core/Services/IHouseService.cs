using Renting.Match.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:20:01 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface IHouseService
    {

		Task<House> GetAsync(Guid id);
    }
}
