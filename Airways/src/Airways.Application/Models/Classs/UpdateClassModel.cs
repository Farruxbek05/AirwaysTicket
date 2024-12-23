using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Classs
{
    public class UpdateClassModel
    {
        
      
        public ClassType className { get; set; }
        public string description { get; set; }
    }
    public class UpdateClassResponceModel : BaseResponceModel { }
}
