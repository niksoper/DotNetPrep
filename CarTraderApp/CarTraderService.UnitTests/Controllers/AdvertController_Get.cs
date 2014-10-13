using CarTrader.AbstractServices;
using CarTraderModel;
using CarTraderService.Controllers;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;
using Xunit.Extensions;

namespace CarTraderService.UnitTests.Controllers
{
    public class AdvertController_Get
    {
        [Theory]
        [PropertyData("Get_TestAdverts")]
        public void Get_ReturnsExpectedAdverts(IEnumerable<Advert> expectedAds, AdvertController sut)
        {
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

                // I've run into issues using AutoFixture to create this object reverted to manually creating it for now...
                var sut = new AdvertController(adRepoMock.Object);

                List<object[]> testParameters = new List<object[]>
                {
                    new object[] { new List<Advert>(), sut },
                    new object[] { fixture.Create<IEnumerable<Advert>>(), sut }
                };

                var sequence = adRepoMock.SetupSequence(x => x.GetAllAdverts());
                testParameters.ForEach(paramList => sequence.Returns((IEnumerable<Advert>)paramList[0]));

                return testParameters;
            }
        }

        [Theory]
        [ClassData(typeof(GetWithExistingIdParams))]
        public void GetWithId_ReturnsExpectedAdvert(int id, Advert expectedAd, AdvertController sut)
        {
            // Act
            var response = sut.Get(id);

            // Assert
            Advert actualAd = null;
            response.TryGetContentValue<Advert>(out actualAd);

            Assert.Same(expectedAd, actualAd);
        }

        [Theory]
        [ClassData(typeof(GetWithExistingIdParams))]
        public void GetWithId_ReturnsSuccessStatusCode(int id, Advert expectedAd, AdvertController sut)
        {
            // Act
            var response = sut.Get(id);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(GetWithNonExistingIdParams))]
        public void GetWithId_ReturnsNullContent(int id, Advert expectedAd, AdvertController sut)
        {
            // Act
            var response = sut.Get(id);

            // Assert
            Advert actualAd = null;
            response.TryGetContentValue<Advert>(out actualAd);

            Assert.Null(actualAd);
        }

        [Theory]
        [ClassData(typeof(GetWithNonExistingIdParams))]
        public void GetWithId_ReturnsNotFoundStatusCode(int id, Advert expectedAd, AdvertController sut)
        {
            // Act
            var response = sut.Get(id);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// Sets up the parameters for the data-driven GetWithId_ReturnsExpectedAdvert test
        /// </summary>
        public abstract class GetWithIdParams : IEnumerable<object[]>
        {
            protected IFixture fixture;
            private object[] testParameters;

            /// <summary>
            /// Initialises a new instance of the <see cref="GetWithIdParams"/> class
            /// </summary>
            public GetWithIdParams()
            {
                this.fixture = new Fixture().Customize(new Helpers.ApiControllerConventions());
                var adRepoMock = fixture.Freeze<Mock<IAdvertRepository>>();

                int id = 1;
                Advert expectedAd = this.ExpectedAdvert();

                // I've run into issues using AutoFixture to create this object reverted to manually creating it for now...
                var sut = new AdvertController(adRepoMock.Object) 
                { 
                    Request = new HttpRequestMessage(), 
                    Configuration = new HttpConfiguration() 
                };

                this.testParameters = new object[] { id, expectedAd, sut };

                adRepoMock.Setup(x => x.GetAdvert((int)this.testParameters[0]))
                    .Returns((Advert)this.testParameters[1]);
            }

            protected abstract Advert ExpectedAdvert();

            public IEnumerator<object[]> GetEnumerator()
            {
                return new List<object[]> { this.testParameters }.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public class GetWithExistingIdParams : AdvertController_Get.GetWithIdParams
        {
            protected override Advert ExpectedAdvert()
            {
                var expectedAd = this.fixture.Create<Advert>();
                return expectedAd;
            }
        }

        public class GetWithNonExistingIdParams : AdvertController_Get.GetWithIdParams
        {
            protected override Advert ExpectedAdvert()
            {
                return null;
            }
        }
    }
}
