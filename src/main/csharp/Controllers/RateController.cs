using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizedRatesHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        /// <summary>
        /// Creates a new rate.
        /// </summary>
        /// <param name="rateDto">The rate to create.</param>
        /// <returns>The created rate.</returns>
        [HttpPost]
        public async Task<ActionResult<RateDto>> CreateRate(RateDto rateDto)
        {
            try
            {
                var createdRate = await _rateService.CreateRateAsync(rateDto);
                return CreatedAtAction(nameof(GetRateById), new { id = createdRate.Id }, createdRate);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a rate by its ID.
        /// </summary>
        /// <param name="id">The ID of the rate.</param>
        /// <returns>The requested rate.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RateDto>> GetRateById(int id)
        {
            try
            {
                var rate = await _rateService.GetRateByIdAsync(id);
                if (rate == null)
                {
                    return NotFound();
                }
                return Ok(rate);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets all rates.
        /// </summary>
        /// <returns>A list of rates.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateDto>>> GetAllRates()
        {
            try
            {
                var rates = await _rateService.GetAllRatesAsync();
                return Ok(rates);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
