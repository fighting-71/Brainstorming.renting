using Renting.Match.Models;
using Renting.Match.Services;
using Command.Extension;
using Renting.Infrastructure.Flags;
using System;
using System.Threading.Tasks;
using Renting.Match.Share.Handlers;

namespace Renting.Match
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:18:59 AM
	/// @source : 
	/// @des : 
	/// </summary>
	public class NewHouseMatchHandler : INewHouseMatchHandler
    {
        private readonly IHouseService houseService;
        private readonly IServiceProvider serviceProvider;
        private readonly ICommonMatchHandler commonMatchHandler;

        public NewHouseMatchHandler(IHouseService houseService, IServiceProvider serviceProvider, ICommonMatchHandler commonMatchHandler)
        {
            this.houseService = houseService;
            this.serviceProvider = serviceProvider;
            this.commonMatchHandler = commonMatchHandler;
        }

        public async Task Run(Guid houseId)
        {

            // 找到对应的房源
            House house = await houseService.GetAsync(houseId);

            if (house == null) return;

            ImplAttribute implimplAttribute = EnumExt.GetAttr<ImplAttribute>(house.Position.Country);

            object impl = serviceProvider.GetService(implimplAttribute.ImplType);

            // 找到对应的处理器进行处理
            Tenancy[] tenancies = await (impl as IMatchHandler).Run(house);

            foreach (var item in tenancies)
            {
                await commonMatchHandler.Run(house, item);
            }

        }

    }
}
