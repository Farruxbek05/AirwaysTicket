using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Aicraft;

public class CreateAircraftModel
{
   
   
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public int SeatCapacity { get; set; }
    public Guid Airline_id { get; set; }

}
    public class CreateAicraftResponceModel : BaseResponceModel { }
