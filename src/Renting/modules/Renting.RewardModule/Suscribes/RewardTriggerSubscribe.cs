using Renting.Reward.Domain.Dto;
using Renting.Reward.Domain.Handlers;
using Renting.Reward.Domain.Models;
using Command.Extension;
using Renting.Infrastructure.Flags;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Renting.Infrastructure.MQModule.Flags;
using Renting.Infrastructure.MQModule;
using Renting.Reward.Services;

namespace Renting.Reward.Suscribes
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/8/2021 2:07:11 PM
	/// @source : 
	/// @des : 
	/// </summary>
    [Subscription("reward.trigger.by.action")]
	public class RewardTriggerSubscribe : IMQSubscribe<NewActionMessage>
    {
        private readonly IRewardService rewardService;
        private readonly IServiceProvider serviceProvider;
        private readonly ITaskCompletedHandler taskCompletedHandler;

        public RewardTriggerSubscribe(IRewardService rewardService, IServiceProvider serviceProvider, ITaskCompletedHandler taskCompletedHandler)
        {
            this.rewardService = rewardService;
            this.serviceProvider = serviceProvider;
            this.taskCompletedHandler = taskCompletedHandler;
        }

        public async Task HandlerAsync(NewActionMessage message)
        {

            ActionInfo actionInfo = await rewardService.GetActionAsync(message.ActionId);

            if (actionInfo == null) return;

            TaskInfo[] taskInfos = await rewardService.GetTasksAsync(actionInfo);

            List<TaskCompleteDto> completed = new List<TaskCompleteDto>();

            foreach (var item in taskInfos)
            {
                ImplAttribute implimplAttribute = EnumExt.GetAttr<ImplAttribute>(item.TaskType);

                var handler = serviceProvider.GetService(implimplAttribute.ImplType) as ITaskCompleteHandler;

                List<TaskCompleteDto> taskCompleteDtos = await handler.RunAsync(item, actionInfo);

                completed.AddRange(taskCompleteDtos);
            }

            foreach (var item in completed)
            {
                await taskCompletedHandler.RunAsync(item);
            }

        }
    }
}
