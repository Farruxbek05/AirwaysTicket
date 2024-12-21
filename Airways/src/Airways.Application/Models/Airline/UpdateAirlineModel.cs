namespace Airways.Application.Models.Airline
{
    public class UpdateAirlineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid Code { get; set; }
    }
    public class UpdateAirlineResponceModel : BaseResponceModel { }
}
