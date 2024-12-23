using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Airline
{
    public class UpdateAirlineModel
    {
     
     
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid Code { get; set; }
    }
    public class UpdateAirlineResponceModel : BaseResponceModel { }
}
