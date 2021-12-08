using Renting.Match.Models;
using Renting.Match.Models.Dto;
using Renting.Match.Services;
using Renting.Match.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Renting.Match.Menu;

namespace Renting.Match.Handler
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 10:51:57 AM
	/// @source : 
	/// @des : 中国地区匹配
	/// </summary>
	public class ChinaMatchHandler : IChinaMatchHandler
    {
        private readonly IHouseMatchStrategy houseMatchStrategy;
        private readonly IServiceProvider serviceProvider;

        public ChinaMatchHandler(IHouseMatchStrategy houseMatchStrategy, IServiceProvider serviceProvider)
        {
            this.houseMatchStrategy = houseMatchStrategy;
            this.serviceProvider = serviceProvider;
        }

        public async Task<Tenancy[]> Run(House house)
        {

            // 获取房源对应的求租匹配
            TenancyMatch[] tenancyMatches = houseMatchStrategy.GetTenancyMatches(house);

            // 并行搜索符合的求租
            Task<Tenancy[]>[] tasks = new Task<Tenancy[]>[tenancyMatches.Length];

            for (int i = 0; i < tenancyMatches.Length; i++)
            {
                var item = tenancyMatches[i];
                //ITenancyService tenancyService = serviceProvider.CreateScope().ServiceProvider.GetService<ITenancyService>();

                //// 获取求租池
                //IQueryable<Tenancy> query = tenancyService.GetPool(house.Position.City);

                tasks[i] = GetMatchTenancy(item, house.Position.City, house.Position.Location);

            }

            await Task.WhenAll(tasks);

            return tasks.SelectMany(x => x.Result).ToArray();

            #region 旧版全量取

            //Dictionary<long, IEnumerable<TenancyMatch>> dictionary = tenancyMatches.GroupBy(u => u.BasicSearchKey).ToDictionary(u => u.Key, u => u.AsEnumerable());

            //var keys = dictionary.Keys;

            //Tenancy[] tenancies = await query.Where(x => keys.Contains(x.BasicSearchKey)).ToArrayAsync();

            //foreach ()

            //foreach (var tenancy in tenancies)
            //{
            //    foreach (var tenancyMatch in dictionary[tenancy.BasicSearchKey])
            //    {
            //        if(tenancy.RentByMonth >= tenancyMatch.MinRentByMonth && tenancy.RentByMonth <= tenancyMatch.MaxRentByMonth)
            //    }
            //}
            #endregion

        }

        /// <summary>
        /// 获取符合的求租
        /// </summary>
        /// <param name="tenancyMatch"></param>
        /// <param name="city"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        protected virtual async Task<Tenancy[]> GetMatchTenancy(TenancyMatch tenancyMatch, ChinaCity city, Location location)
        {

            ITenancyService tenancyService = serviceProvider.CreateScope().ServiceProvider.GetService<ITenancyService>();

            // 获取求租池
            IQueryable<Tenancy> query = tenancyService.GetPool(city);

            // 根据求租匹配 进行筛选查询
            var tenancies = await query.Where(x => x.BasicSearchKey == tenancyMatch.BasicSearchKey && x.RentByMonth >= tenancyMatch.MinRentByMonth && x.RentByMonth <= tenancyMatch.MaxRentByMonth).ToArrayAsync();

            // 过滤位置距离
            return tenancies.Where(x => x.Positions.Any(u => u.Location.GetDistance(location) < tenancyMatch.MaxDistance)).ToArray();

        }

    }
}
