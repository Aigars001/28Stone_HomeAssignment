namespace _28Stone_HomeAssignment.Models
{
    public class CountryModel
    {
        public string? Name { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public List<string>? TopLevelDomain { get; set; }
        public bool Independent { get; set; }
        public string? NativeName { get; set; }
        public string? SubRegion { get; set; }
        public string? Capital { get; set; }
    }
}
