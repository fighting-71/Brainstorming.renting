using Renting.Match.Flags;
using Renting.Match.Models;
using Renting.Match.Services;
using Command.Extension;
using Renting.Infrastructure.Flags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renting.Match
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:18:59 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public class DefaultMatchCore
    {
        private readonly IHouseService houseService;
        private readonly IServiceProvider serviceProvider;

        public DefaultMatchCore(IHouseService houseService, IServiceProvider serviceProvider)
        {
            this.houseService = houseService;
            this.serviceProvider = serviceProvider;
        }

        public async Task Run(Guid houseId)
        {

            // 找到对应的房源
            House house = await houseService.GetAsync(houseId);

            if (house == null) return;

            ImplAttribute implimplAttribute = EnumExt.GetAttr<ImplAttribute>(house.Position.Country);

            object impl = serviceProvider.GetService(implimplAttribute.ImplType);

            // 找到对应的处理器进行处理
            await (impl as IMatchHandler).Run(house);

        }

    }
}
