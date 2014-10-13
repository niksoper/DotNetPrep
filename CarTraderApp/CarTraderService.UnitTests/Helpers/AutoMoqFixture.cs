using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace CarTraderService.UnitTests.Helpers
{
    class AutoMoqFixture : Fixture
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AutoMoqFixture"/> class, which has support for automatic mocking of components.
        /// </summary>
        public AutoMoqFixture()
        {
            this.Customize(new AutoMoqCustomization());
        }
    }
}
