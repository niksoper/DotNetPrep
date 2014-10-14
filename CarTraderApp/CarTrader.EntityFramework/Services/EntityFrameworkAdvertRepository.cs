using AutoMapper;
using CarTrader.AbstractServices;
using CarTrader.EntityFramework.Context;
using CarTrader.EntityFramework.Entities;
using CarTraderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrader.EntityFramework.Services
{
    public class EntityFrameworkAdvertRepository : IAdvertRepository
    {
        private CarTraderContext db;
        private IObjectMap mapper;

        public EntityFrameworkAdvertRepository()
        {
            this.db = new CarTraderContext();
            this.mapper = new AutoMapperMap();
        }

        public void AddAdvert(Advert ad)
        {
            var adEntity = this.mapper.Map<AdvertEntity>(ad);
            adEntity.CreatedTime = DateTime.Now;
            this.db.Adverts.Add(adEntity);
            this.db.SaveChanges();
        }

        public IEnumerable<Advert> GetAllAdverts()
        {
            var adList = db.Adverts.ToList();
            return adList.Select(ad => this.mapper.Map<Advert>(ad));
        }

        public Advert GetAdvert(int id)
        {
            return this.mapper.Map<Advert>(this.db.Adverts.FirstOrDefault(ad => ad.Id == id));
        }

        public void DeleteAdvert(int id)
        {
            var targetAd = this.db.Adverts.FirstOrDefault(ad => ad.Id == id);
            if (targetAd != null)
            {
                this.db.Adverts.Remove(targetAd);
            }
        }

        public bool UpdateAdvert(int id, Advert updatedAd)
        {
            var targetAd = this.db.Adverts.FirstOrDefault(ad => ad.Id == id);
            if (targetAd == null)
            {
                return false;
            }

            this.mapper.Update(updatedAd, targetAd);

            return true;
        }
    }
}
