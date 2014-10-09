using CarTraderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarTraderService.Controllers
{
    public class AdvertController : ApiController
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

        public IEnumerable<Advert> Get()
        {
            return adverts;
        }

        public HttpResponseMessage Get(int id)
        {
            var targetAd = adverts.FirstOrDefault(ad => ad.Id == id);

            return (targetAd == null)
                ? this.Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("No advert found with id: {0}.", id))
                : this.Request.CreateResponse(HttpStatusCode.OK, targetAd);
        }

        public HttpResponseMessage Post([FromBody]Advert ad)
        {
            if (ad == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No advert data was submitted.");
            }

            nextAdId++;
            ad.Id = nextAdId;
            adverts.Add(ad);

            var response = this.Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(this.Request.RequestUri + ad.Id.ToString());

            return response;
        }

        public HttpResponseMessage Put(int id, [FromBody]Advert updatedAd)
        {
            var targetAd = adverts.FirstOrDefault(ad => ad.Id == id);

            if (targetAd == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("No advert found with id: {0}.", id));
            }

            targetAd.CopyDetail(updatedAd);
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage Delete(int id)
        {
            var targetAd = adverts.FirstOrDefault(ad => ad.Id == id);
            adverts.Remove(targetAd);

            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
