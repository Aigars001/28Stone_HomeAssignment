using _28Stone_HomeAssignment.Interfaces;
using _28Stone_HomeAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace _28Stone_HomeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountry _country;

        public CountriesController(ICountry country)
        {
            _country = country;
        }

        [Route("toptenpopulation")]
        [HttpGet]
        public async Task<IActionResult> GetTopTenCountriesByPopulation()
        {
            var getAllCountries = await _country.GetCountries();

            return Ok(CountryService.SortByPopulation(getAllCountries).Take(10));
        }

        [Route("toptendensity")]
        [HttpGet]
        public async Task<IActionResult> GetTopTenCountriesByDensity()
        {
            var getAllCountries = await _country.GetCountries();

            return Ok(CountryService.SortByDensity(getAllCountries).Take(10));
        }

        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            var getAllCountries = await _country.GetCountries();
            var getCountryByName = await _country.GetCountryByName(name);
            var country = getAllCountries.FirstOrDefault(c => c.Name?.ToLower() == name.ToLower());

            if(country == null || !CountryService.IsEuropeanCountry(getAllCountries, country))
            {
                return BadRequest($"{name} is not in Europian Union");
            }

            return Ok(CountryService.GetCountryByName(country));
        }
    }
}
