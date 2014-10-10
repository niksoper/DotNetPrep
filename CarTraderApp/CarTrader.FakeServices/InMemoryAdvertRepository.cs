using CarTrader.AbstractServices;
using CarTraderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrader.FakeServices
{
    public class InMemoryAdvertRepository : IAdvertRepository
    {
        private static int nextAdId;
        private static List<Advert> adverts = StartingAds();

        private static List<Advert> StartingAds()
        {
            var ads = new List<Advert>
            {
                new Advert { Id = 1, Make = "Ford", Model = "Fiesta", AskingPrice = 2095, ContactNumber = "01225 456123", Description = "A lovely drive, honest." },
                new Advert { Id = 2, Make = "Mini", Model = "Cooper", AskingPrice = 5000, ContactNumber = "07713715462", Description = "Horrible. Stay away!" },
                new Advert { Id = 3, Make = "Alan", Model = "Horse", AskingPrice = 10, ContactNumber = "07716829674", Description = "Simply a bargain" }
            };

            ads.ForEach(ad => ad.CreatedTime = DateTime.Now);

            nextAdId = ads.Count + 1;

            return ads;
        }

        public IEnumerable<Advert> GetAllAdverts()
        {
            return adverts;
        }

        public Advert GetAdvert(int id)
        {
            return adverts.FirstOrDefault(ad => ad.Id == id);
        }

        public void DeleteAdvert(int id)
        {
            var targetAd = adverts.FirstOrDefault(ad => ad.Id == id);
            adverts.Remove(targetAd);
        }

        public bool UpdateAdvert(int id, Advert ad)
        {
            var targetAd = adverts.FirstOrDefault(a => a.Id == id);

            if (targetAd == null)
            {
                return false;
            }

            targetAd.CopyDetail(ad);
            return true;
        }

        public void AddAdvert(Advert ad)
        {
            nextAdId++;
            ad.Id = nextAdId;
            adverts.Add(ad);
        }
    }
}
