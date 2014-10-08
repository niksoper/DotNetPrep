using CarTraderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarTraderService.Controllers
{
    public class AdvertController : ApiController
    {
        private static List<Advert> adverts = StartingAds();

        private static List<Advert> StartingAds()
        {
            return new List<Advert>
            {
                new Advert { Id = 1, Make = "Ford", Model = "Fiesta", AskingPrice = 2095, ContactNumber = "01225 456123", Description = "A lovely drive, honest." },
                new Advert { Id = 2, Make = "Mini", Model = "Cooper", AskingPrice = 5000, ContactNumber = "07713715462", Description = "Horrible. Stay away!" },
                new Advert { Id = 3, Make = "Alan", Model = "Horse", AskingPrice = 10, ContactNumber = "07716829674", Description = "Simply a bargain" }
            };
        }

        public IEnumerable<Advert> Get()
        {
            return adverts;
        }

        public Advert Get(int id)
        {
            return adverts.FirstOrDefault(ad => ad.Id == id);
        }
    }
}
