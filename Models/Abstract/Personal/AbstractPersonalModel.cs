#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region JT Express
// Interface
using JtExpressCore.Interfaces.Models.JtExpress;
#endregion

namespace JtExpressCore.Models.Abstract
{
  public abstract class AbstractPersonalModel: IPersonalModel
  {
    [JsonProperty(PropertyName = "prov")]
    public string province { get; set; }
    [JsonProperty(PropertyName = "city")]
    public string district { get; set; }
    [JsonProperty(PropertyName = "area")]
    public string ward { get; set; }
  }
}

