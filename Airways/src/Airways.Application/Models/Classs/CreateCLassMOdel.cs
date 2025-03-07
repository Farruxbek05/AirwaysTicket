using Airways.Core.Entity;
using System.Text.Json.Serialization;

namespace Airways.Application.Models.Classs;

public class CreateCLassModel
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ClassType className { get; set; }
    public string description { get; set; }
}
public class CreateClassResponceModel : BaseResponceModel { }

