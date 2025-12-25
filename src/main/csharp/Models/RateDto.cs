using System;

namespace CentralizedRatesHub.Models
{
    public class RateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        // Additional properties for complex pricing management
    }
}
