using Renting.Match.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Services
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 11:01:17 AM
	/// @source : 
	/// @des : 获取检索key
	/// </summary>
	public interface IGetBasicSearchKeyService
    {
		long GetBasicSearchKey(BaseIssuerInfo baseIssuerInfo);
	}
}
