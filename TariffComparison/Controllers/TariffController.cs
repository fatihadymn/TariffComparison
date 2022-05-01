using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Core.Services;
using TariffComparison.Items.Exceptions;
using TariffComparison.Items.Models.Response;
using TariffComparison.Items.Queries;

namespace TariffComparison.Controllers
{
    [Route("api/tariffcomparison/v1/tariffs")]
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;

        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TariffDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTariffs([FromQuery] GetTariffsRequest query)
        {
            return Ok(await _tariffService.GetTariffs(query));
        }
    }
}
