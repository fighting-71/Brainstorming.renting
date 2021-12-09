using Renting.Match.Menu;
using Renting.Match.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renting.Match.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:18:42 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public interface ITenancyService
    {
		IQueryable<Tenancy> GetPool(ChinaCity city);
    }
}
