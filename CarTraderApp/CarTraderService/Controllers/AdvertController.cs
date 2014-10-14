using CarTrader.AbstractServices;
using CarTrader.EntityFramework.Services;
using CarTrader.FakeServices;
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
        /// <summary>
        /// Contains all adverts
        /// </summary>
        private readonly IAdvertRepository adverts;

        /// <summary>
        /// Initialises a new instance of the <see cref="AdvertController"/> class
        /// </summary>
        public AdvertController()
            : this(new EntityFrameworkAdvertRepository())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AdvertController"/> class
        /// </summary>
        /// <param name="advertRepository">The repository that contains all adverts.</param>
        public AdvertController(IAdvertRepository advertRepository)
        {
            if (advertRepository == null)
            {
                throw new ArgumentNullException("advertRepository");
            }

            this.adverts = advertRepository;
        }

        public IEnumerable<Advert> Get()
        {
            return this.adverts.GetAllAdverts();
        }

        public HttpResponseMessage Get(int id)
        {
            var targetAd = this.adverts.GetAdvert(id);

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

            this.adverts.AddAdvert(ad);

            var response = this.Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(this.Request.RequestUri + ad.Id.ToString());

            return response;
        }

        public HttpResponseMessage Put(int id, [FromBody]Advert ad)
        {
            bool updated = this.adverts.UpdateAdvert(id, ad);

            if (!updated)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("No advert found with id: {0}.", id));
            }

            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage Delete(int id)
        {
            this.adverts.DeleteAdvert(id);

            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
