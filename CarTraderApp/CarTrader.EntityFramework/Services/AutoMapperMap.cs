using CarTrader.EntityFramework.Entities;
using CarTraderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrader.EntityFramework.Services
{
    class AutoMapperMap : IObjectMap
    {
        static AutoMapperMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Advert, AdvertEntity>();
                cfg.CreateMap<AdvertEntity, Advert>();
            });
        }

        public T Map<T>(object source)
        {
            return AutoMapper.Mapper.Map<T>(source);
        }

        public TTarget Update<TTarget, TSource>(TSource source, TTarget destination)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source, destination);
        }
    }
}
