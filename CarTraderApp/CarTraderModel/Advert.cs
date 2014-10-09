using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTraderModel
{
    /// <summary>
    /// An advert for a car that is for sale
    /// </summary>
    public class Advert
    {
        /// <summary>
        /// Gets or sets the id of the advert
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the make of the car in the advert
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model of the car in the advert
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the asking price of the advert
        /// </summary>
        public decimal AskingPrice { get; set; }

        /// <summary>
        /// Gets or sets the description of the car in the advert
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the contact number of the seller
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the date and time that the advert was created
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Copies the details from another advert to this advert
        /// </summary>
        /// <param name="adDetails">The details to copy to this advert</param>
        public void CopyDetail(Advert adDetails)
        {
            this.Make = adDetails.Make;
            this.Model = adDetails.Model;
            this.AskingPrice = adDetails.AskingPrice;
            this.Description = adDetails.Description;
            this.ContactNumber = adDetails.ContactNumber;
            this.CreatedTime = adDetails.CreatedTime;
        }
    }
}
