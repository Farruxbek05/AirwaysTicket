namespace Airways.Application.Models.Classs
{
    public class UpdateClassModel
    {
        public int ID { get; set; }
        public ClassType className { get; set; }
        public string description { get; set; }
    }
    public class UpdateClassResponceModel : BaseResponceModel { }
}
