using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Controllers;
using TariffComparison.Core.Services;
using TariffComparison.Items.Exceptions;
using TariffComparison.Items.Models.Enum;
using TariffComparison.Items.Models.Response;
using TariffComparison.Items.Queries;
using Xunit;

namespace TariffComparison.Test
{
    public class TariffControllerTests
    {
        [Theory]
        [InlineData(3500, 830, 800)]
        [InlineData(4500, 1050, 950)]
        [InlineData(6000, 1380, 1400)]
        public async Task TariffController_GetTariff_ShouldReturnOk_ExpectedValueAsync(decimal consumption, decimal basicCost, decimal packagedCost)
        {
            //Arrange
            var tariffServiceMock = new Mock<ITariffService>();

            var request = new GetTariffsRequest()
            {
                Consumption = consumption
            };

            var response = new List<TariffDto>()
                {
                    new TariffDto()
                    {
                        AnnualCosts = basicCost,
                        TariffName = $"{TariffName.Basic} Tariff"
                    },
                    new TariffDto()
                    {
                        AnnualCosts = packagedCost,
                        TariffName = $"{TariffName.Packaged} Tariff"
                    }
                };

            tariffServiceMock
                .Setup(x => x.GetTariffs(request))
                .ReturnsAsync(() => response);

            var tariffController = CreateInstance(tariffServiceMock);

            //Act
            var result = await tariffController.GetTariffs(request);

            var values = (List<TariffDto>)((ObjectResult)result).Value;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotEmpty(values);
            Assert.Equal(2, values.Count);
            Assert.Equal(basicCost, values.FirstOrDefault(x => x.TariffName == $"{TariffName.Basic} Tariff").AnnualCosts);
            Assert.Equal(packagedCost, values.FirstOrDefault(x => x.TariffName == $"{TariffName.Packaged} Tariff").AnnualCosts);
        }

        [Fact]
        public async Task TariffController_GetTariff_ShouldReturn_BadRequest_WithNotExistPackageAsync()
        {
            try
            {
                //Arrange
                var tariffServiceMock = new Mock<ITariffService>();

                tariffServiceMock
                    .Setup(x => x.GetTariffs(It.IsAny<GetTariffsRequest>()))
                    .Throws(
                      new BusinessException("Tariff type is not supported. Tariff Type : NotExistTariff")
                    );

                var tariffController = CreateInstance(tariffServiceMock);

                //Act
                var result = await tariffController.GetTariffs(new GetTariffsRequest());

                var values = (List<TariffDto>)((ObjectResult)result).Value;
            }
            catch (BusinessException ex)
            {
                //Assert
                Assert.NotNull(ex.Message);
                Assert.IsType<BusinessException>(ex);
            }
        }


        private TariffController CreateInstance(Mock<ITariffService> tariffServiceMock)
        {
            var tariffController = new TariffController(tariffServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            return tariffController;
        }
    }
}
