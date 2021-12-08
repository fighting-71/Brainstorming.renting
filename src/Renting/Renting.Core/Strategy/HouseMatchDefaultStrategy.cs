using Renting.Match.Flags;
using Renting.Match.Menu;
using Renting.Match.Models;
using Renting.Match.Models.Dto;
using Renting.Match.Services;
using Command.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Match.Strategy
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/7/2021 1:30:38 PM
	/// @source : 
	/// @des : 房源默认匹配策略
	/// </summary>
	public class HouseMatchDefaultStrategy : IHouseMatchStrategy
    {
        private readonly IGetBasicSearchKeyService getBasicSearchKeyService;

        public HouseMatchDefaultStrategy(IGetBasicSearchKeyService getBasicSearchKeyService)
        {
            this.getBasicSearchKeyService = getBasicSearchKeyService;
        }

        public TenancyMatch[] GetTenancyMatches(House house)
        {

            List<TenancyMatch> tenancies = new List<TenancyMatch>(house.Room);

            double maxDistance = GetMaxDistance(house);

            switch (house.HouseType)
            {
                case HouseType.Entire:
                    {
                        {
                            TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                            SetRentRange(tenancyMatch, house.RentByMonth, house.HouseType, HouseType.Entire, house.Position.Country);

                            tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = house.Room, HouseType = HouseType.Entire});

                            tenancies.Add(tenancyMatch);
                        }
                        {
                            TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                            SetRentRange(tenancyMatch, house.RentByMonth, house.HouseType, HouseType.Share, house.Position.Country);

                            tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = house.Room, HouseType = HouseType.Share });

                            tenancies.Add(tenancyMatch);
                        }
                        {
                            TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                            SetRentRange(tenancyMatch, house.RentByMonth, house.HouseType, HouseType.Single, house.Position.Country);

                            tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = house.Room, HouseType = HouseType.Single });

                            tenancies.Add(tenancyMatch);
                        }
                    }
                    break;
                case HouseType.Share:
                    {
                        TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                        SetRentRange(tenancyMatch, house.RentByMonth, house.HouseType, HouseType.Entire, house.Position.Country);

                        tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = house.Room, HouseType = HouseType.Entire });

                        tenancies.Add(tenancyMatch);
                    }
                    for (int i = 1; i <= house.Room; i++)
                    {
                        var rent = house.RentByMonth * i / house.Room;

                        {
                            TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                            SetRentRange(tenancyMatch, rent, house.HouseType, HouseType.Share, house.Position.Country);

                            tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = i, HouseType = HouseType.Share });

                            tenancies.Add(tenancyMatch);
                        }
                    }
                    break;
                case HouseType.Single:
                    {
                        for (int i = 1; i <= house.Room; i++)
                        {
                            var rent = house.RentByMonth * i / house.Room;

                            {
                                TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                                SetRentRange(tenancyMatch, rent, house.HouseType, HouseType.Share, house.Position.Country);

                                tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = i, HouseType = HouseType.Share });

                                tenancies.Add(tenancyMatch);
                            }

                            {
                                TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                                SetRentRange(tenancyMatch, rent, house.HouseType, HouseType.Single, house.Position.Country);

                                tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = i, HouseType = HouseType.Single });

                                tenancies.Add(tenancyMatch);
                            }
                        }
                    }
                    break;
                case HouseType.Bed:
                    {
                        for (int i = 1; i <= house.Room; i++)
                        {
                            var rent = house.RentByMonth * i / house.Room;

                            TenancyMatch tenancyMatch = new TenancyMatch { MaxDistance = maxDistance };

                            SetRentRange(tenancyMatch, rent, house.HouseType, HouseType.Share, house.Position.Country);

                            tenancyMatch.BasicSearchKey = getBasicSearchKeyService.GetBasicSearchKey(new BaseIssuerInfo { Room = i, HouseType = HouseType.Share });

                            tenancies.Add(tenancyMatch);
                        }
                    }
                    break;
                default:
                    break;
            }

            return tenancies.ToArray();
        }

        /// <summary>
        /// 填充租金范围
        /// </summary>
        /// <param name="tenancyMatch"></param>
        /// <param name="rent"></param>
        /// <param name="houseType"></param>
        /// <param name="tenancyHouseType"></param>
        /// <param name="country"></param>
        protected virtual void SetRentRange(TenancyMatch tenancyMatch, int rent, HouseType houseType, HouseType tenancyHouseType, Country country)
        {
            if(houseType != tenancyHouseType && houseType == HouseType.Entire)
            {
                if(country == Country.Britain)
                {
                    tenancyMatch.MinRentByMonth = rent - 10;
                    tenancyMatch.MaxRentByMonth = rent + 10;
                }
                else
                {
                    tenancyMatch.MinRentByMonth = rent - 100;
                    tenancyMatch.MaxRentByMonth = rent + 100;
                }
            }
            else
            {
                if (rent >= 4000)
                {
                    tenancyMatch.MinRentByMonth = rent - 1000;
                    tenancyMatch.MaxRentByMonth = rent + 700;
                }
                else
                {
                    tenancyMatch.MinRentByMonth = rent - 1000;
                    tenancyMatch.MaxRentByMonth = rent + 500;
                }
            }
        }

        /// <summary>
        /// 获取匹配距离范围
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        protected virtual double GetMaxDistance(House house)
        {
            return house.Position.City.GetAttr<DistanceLimitAttribute>().Default;
        }

    }
}
