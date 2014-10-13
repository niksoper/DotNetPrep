using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTraderService.UnitTests.Helpers
{
    internal class ApiControllerConventions : CompositeCustomization
    {
        internal ApiControllerConventions()
            : base(
                new HttpRequestMessageCustomization(),
                new ApiControllerCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
}
