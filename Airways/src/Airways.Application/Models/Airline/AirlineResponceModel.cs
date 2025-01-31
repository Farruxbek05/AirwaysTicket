using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Airline
{
    public class AirlineResponceModel:BaseResponceModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
