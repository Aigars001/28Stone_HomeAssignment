using _28Stone_HomeAssignment.Models;
using Refit;

namespace _28Stone_HomeAssignment.Interfaces
{
    public interface ICountry
    {
        [Get("/v2/regionalbloc/eu")]
        Task<List<CountryModel>> GetCountries();

        [Get("/v2/name/{name}")]
        Task<List<CountryModel>> GetCountryByName(string name);
    }
}
