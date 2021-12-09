using Renting.Match.Models;
using Renting.Match.Share.Dto;
using Renting.Match.Share.Handlers;
using Renting.Match.Share.Menu;
using Renting.Match.Share.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match.Handler
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/9/2021 11:14:41 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public class CommonMatchHandler : ICommonMatchHandler
    {

        private readonly IMatchCheckService matchCheckService;
        private readonly IMatchSuccessHandler matchSuccessHandler;
        private readonly IMatchInvalidHandler matchInvalidHandler;
        private readonly IMatchPrepareHandler matchPrepareHandler;

        public CommonMatchHandler(IMatchCheckService matchCheckService, IMatchSuccessHandler matchSuccessHandler, IMatchInvalidHandler matchInvalidHandler, IMatchPrepareHandler matchPrepareHandler)
        {
            this.matchCheckService = matchCheckService;
            this.matchSuccessHandler = matchSuccessHandler;
            this.matchInvalidHandler = matchInvalidHandler;
            this.matchPrepareHandler = matchPrepareHandler;
        }

        public async Task Run(House house, Tenancy item)
        {
            UserMatchCheckResult userMatchResult = await matchCheckService.UserCheckAsync(item.UserId, house.UserId);

            if (!userMatchResult.IsMatch)
            {
                await matchInvalidHandler.RunAsync(house, item, userMatchResult.MatchInvalidType.Value, userMatchResult.InvalidReson);

                return;
            }

            bool flag = await matchCheckService.IdentityCheckAsync(item.UserId, house.UserId);

            if (!flag)
            {
                await matchPrepareHandler.RunAsync(house, item, MatchPrepareType.IdentityIsMatch);

                return;
            }

            await matchSuccessHandler.RunAsync(house, item, MatchChannel.NewHouse);
        }
    }
}
