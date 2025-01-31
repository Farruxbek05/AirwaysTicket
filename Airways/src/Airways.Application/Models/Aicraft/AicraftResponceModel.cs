using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Aicraft
{
    public class AicraftResponceModel:BaseResponceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int SeatCapacity { get; set; }
    }
}
