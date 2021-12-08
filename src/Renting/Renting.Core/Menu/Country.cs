using Renting.Infrastructure.Flags;

namespace Renting.Match.Menu
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/7/2021 10:10:43 AM
    /// @source : 
    /// @des : 国家
    /// </summary>
    public enum Country
    {
		[Impl(typeof(IChinaMatchHandler))]
		China,
		[Impl(typeof(IBritainMatchHandler))]
		Britain
	}
}
