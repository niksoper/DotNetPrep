using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTraderModel;

namespace CarTrader.AbstractServices
{
    public interface IAdvertRepository
    {
        void AddAdvert(Advert ad);
        IEnumerable<Advert> GetAllAdverts();
        Advert GetAdvert(int id);
        void DeleteAdvert(int id);
        bool UpdateAdvert(int id, Advert ad);
    }
}
