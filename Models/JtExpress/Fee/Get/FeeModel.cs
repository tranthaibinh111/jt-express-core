#region Package (third-party)
using Newtonsoft.Json;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  /// <summary>
  /// https://api-docs.jtexpress.vn/api/api-4/
  /// </summary>
  public class FeeModel: ResponseItemModel
  {
    // Phí vận chuyển
    [JsonProperty(PropertyName = "price")]
    public decimal fee { get; set; }
    // Phí COD
    [JsonProperty(PropertyName = "codfee")]
    public decimal codFee { get; set; }
    // Phí bảo hiểm(khai giá)
    [JsonProperty(PropertyName = "insurancefee")]
    public decimal insuranceFee { get; set; }
  }
}

