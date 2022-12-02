using _28Stone_HomeAssignment.Models;
using _28Stone_HomeAssignment.Services;
using Newtonsoft.Json;

namespace EuCountriesTest
{
    public class CountryTest
    {
        private readonly List<CountryModel> _europeanCountriesTestList = new()
    {
        new CountryModel
        {
            Name = "Latvia",
            Area = 64559,
            Population = 1901548,
            TopLevelDomain = new List<string> {".lv"},
            NativeName = "Latvija",
            Independent = true,
            SubRegion = "Northern Europe",
            Capital = "Riga"
        },
        new CountryModel
        {
            Name = "Spain",
            Area = 505992,
            Population = 47351567,
            TopLevelDomain = new List<string> {".es"},
            NativeName = "España",
            Independent = true,
            SubRegion = "Southern Europe",
            Capital = "Madrid"
        },
        new CountryModel
        {
            Name = "Italy",
            Area = 301336,
            Population = 59554023,
            TopLevelDomain = new List<string> {".it"},
            NativeName = "Italia",
            Independent = true,
            SubRegion = "Southern Europe",
            Capital = "Rome"
        },
        new CountryModel
        {
            Name = "Palestine",
            Area = 6220,
            Population = 4803269,
            TopLevelDomain = new List<string> {".it"},
            NativeName = "???? ??????",
            Independent = false,
            SubRegion = "Western Asia",
            Capital = "Ramallah"
        }
    };

        [Fact]
        public void GetIndependentEUCountries_Palestine_ReturnsFalse()
        {
            var country = new CountryModel
            {
                Name = "Latvia",
                Area = 64559,
                Population = 1901548,
                TopLevelDomain = new List<string> { ".lv" },
                NativeName = "Latvija",
                Independent = true,
                SubRegion = "Northern Europe",
                Capital = "Riga"
            };

            var result = CountryService.IsEuropeanCountry(_europeanCountriesTestList, country);

            Assert.True(result);
        }

        [Fact]
        public void GetIndependentEUCountries_Latvia_ReturnsTrue()
        {
            var country = new CountryModel
            {
                Name = "Palestine",
                Area = 6220,
                Population = 4803269,
                TopLevelDomain = new List<string> { ".it" },
                NativeName = "???? ??????",
                Independent = false,
                SubRegion = "Western Asia",
                Capital = "Ramallah"
            };

            var result = CountryService.IsEuropeanCountry(_europeanCountriesTestList, country);

            Assert.False(result);
        }

        [Fact]
        public void SortEuCountriesByPopulation()
        {
            var expected = new List<CountryModel>
            {
                new CountryModel
                {
                    Name = "Italy",
                    Area = 301336,
                    Population = 59554023,
                    TopLevelDomain = new List<string> {".it"},
                    NativeName = "Italia",
                    Independent = true,
                    SubRegion = "Southern Europe",
                    Capital = "Rome"
                },
                new CountryModel
                {
                    Name = "Spain",
                    Area = 505992,
                    Population = 47351567,
                    TopLevelDomain = new List<string> {".es"},
                    NativeName = "España",
                    Independent = true,
                    SubRegion = "Southern Europe",
                    Capital = "Madrid"
                },
                new CountryModel
                {
                    Name = "Latvia",
                    Area = 64559,
                    Population = 1901548,
                    TopLevelDomain = new List<string> {".lv"},
                    NativeName = "Latvija",
                    Independent = true,
                    SubRegion = "Northern Europe",
                    Capital = "Riga"
                },
            };

            var result = CountryService.SortByPopulation(_europeanCountriesTestList).ToList();

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void SortEuCountriesByDensity()
        {
            var expected = new List<CountryModel>
            {
                new CountryModel
                {
                    Name = "Italy",
                    Area = 301336,
                    Population = 59554023,
                    TopLevelDomain = new List<string> {".it"},
                    NativeName = "Italia",
                    Independent = true,
                    SubRegion = "Southern Europe",
                    Capital = "Rome"
                },
                new CountryModel
                {
                    Name = "Spain",
                    Area = 505992,
                    Population = 47351567,
                    TopLevelDomain = new List<string> {".es"},
                    NativeName = "España",
                    Independent = true,
                    SubRegion = "Southern Europe",
                    Capital = "Madrid"
                },
                new CountryModel
                {
                    Name = "Latvia",
                    Area = 64559,
                    Population = 1901548,
                    TopLevelDomain = new List<string> {".lv"},
                    NativeName = "Latvija",
                    Independent = true,
                    SubRegion = "Northern Europe",
                    Capital = "Riga"
                },
            };

            var result = CountryService.SortByDensity(_europeanCountriesTestList).ToList();

            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }
}