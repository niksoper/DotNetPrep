using CarTrader.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrader.EntityFramework.Context
{
    public class CarTraderInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarTraderContext>
    {
        protected override void Seed(CarTraderContext context)
        {
            var ads = new List<AdvertEntity>
            {
                new AdvertEntity { Make = "Ford", Model = "Sierra", AskingPrice = 2095, ContactNumber = "01225 456123", Description = "Awesome." },
                new AdvertEntity { Make = "Mini", Model = "Metro", AskingPrice = 5000, ContactNumber = "07713715462", Description = "This is a car, I think." },
                new AdvertEntity { Make = "Wacky", Model = "Racer", AskingPrice = 10, ContactNumber = "07716829674", Description = "You won't find another one like this." }
            };

            foreach (var ad in ads)
            {
                ad.CreatedTime = DateTime.Now;
                context.Adverts.Add(ad);
            }

            context.SaveChanges();
        }
    }
}
