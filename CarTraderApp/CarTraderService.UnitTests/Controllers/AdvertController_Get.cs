using CarTrader.AbstractServices;
using CarTraderModel;
using CarTraderService.Controllers;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace CarTraderService.UnitTests.Controllers
{
    public class AdvertController_Get
    {
        [Theory]
        [PropertyData("Get_TestAdverts")]
        public void Get_ReturnsExpectedAdverts(IEnumerable<Advert> expectedAds, Mock<IAdvertRepository> adRepoMock)
        {
            // Arrange
            // I've run into issues using AutoFixture to create this object reverted to manually creating it for now...
            var sut = new AdvertController(adRepoMock.Object);

            // Act
            var result = sut.Get();

            // Assert
            Assert.Same(expectedAds, result);
        }
        
        /// <summary>
        /// Gets a series of parameter sets to use with the data-driven Get_ReturnsExpectedAdverts test
        /// </summary>
        public static IEnumerable<object[]> Get_TestAdverts
        {
            get
            {
                IFixture fixture = new Helpers.AutoMoqFixture();
                var adRepoMock = fixture.Freeze<Mock<IAdvertRepository>>();

                List<object[]> testParameters = new List<object[]>
                {
                    new object[] { new List<Advert>(), adRepoMock },
                    new object[] { fixture.Create<IEnumerable<Advert>>(), adRepoMock }
                };

                var sequence = adRepoMock.SetupSequence(x => x.GetAllAdverts());
                testParameters.ForEach(paramList => sequence.Returns((IEnumerable<Advert>)paramList[0]));

                return testParameters;
            }
        }
    }
}
