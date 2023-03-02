#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  public class FeeModel: ResponseItemModel
  {
    // Phí vận chuyển
    [JsonProperty(PropertyName = "inquiryfee")]
    public decimal fee { get; set; }
    // Phí COD
    [JsonProperty(PropertyName = "codfee")]
    public decimal codFee { get; set; }
    // Phí bảo hiểm(khai giá)
    [JsonProperty(PropertyName = "insurancefee")]
    public decimal insuranceFee { get; set; }
  }
}

