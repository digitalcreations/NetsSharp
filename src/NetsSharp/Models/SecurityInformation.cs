namespace NetsSharp.Models
{
    public class SecurityInformation
    {
        // ReSharper disable once InconsistentNaming
        public string CustomerIPCountry { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool IPCountryMatchesIssuingCountry { get; set; }
    }
}