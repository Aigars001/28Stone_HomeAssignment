using _28Stone_HomeAssignment.Models;

namespace _28Stone_HomeAssignment.Services
{
    public class CountryFilter
    {
        private static IEnumerable<CountryModel> EuropianUnionCountries(List<CountryModel> country)
        {
            var euroCountriesList = country.Where(c => c.Independent);

            return euroCountriesList;
        }

        public static IEnumerable<CountryModel> SortByPopulation(List<CountryModel> country)
        {
            var euroUnionCountries = EuropianUnionCountries(country);
            var top10PopulationCountries = euroUnionCountries.OrderByDescending(c => c.Population);

            return top10PopulationCountries;
        }

        public static IEnumerable<CountryModel> SortByDensity(List<CountryModel> country)
        {
            var euroUnionCountries = EuropianUnionCountries(country);
            var top10DensityCountries = euroUnionCountries.OrderByDescending(c => c.Population / c.Area);

            return top10DensityCountries;
        }

        public static bool IsEuropeanCountry(List<CountryModel> country, CountryModel name)
        {
            var euroUnionCountries = EuropianUnionCountries(country);

            return euroUnionCountries.Any(c => c.Name == name.Name);
        }

        public static CountryModel GetCountryByName(CountryModel country)
        {
            var model = new CountryModel()
            {
                NativeName = country.NativeName,
                Population = country.Population,
                Area = country.Area,
                Independent = country.Independent,
                TopLevelDomain = country.TopLevelDomain,
                SubRegion = country.SubRegion,
                Capital = country.Capital,
            };

            return model;
        }
    }
}
