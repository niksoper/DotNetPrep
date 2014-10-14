using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrader.EntityFramework.Services
{
    interface IObjectMap
    {
        T Map<T>(object source);
        TDestination Update<TDestination, TSource>(TSource source, TDestination destination);
    }
}
