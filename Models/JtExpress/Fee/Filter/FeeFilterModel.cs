#region DotNet
using System;
#endregion

#region Package (third-party)
using AutoMapper;

#region Newtonsoft
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion
#endregion

namespace JtExpressCore.Models.JtExpress
{
  /// <summary>
  /// https://api-docs.jtexpress.vn/api/api-4/
  /// </summary>
  public class FeeFilterModel
  {
    // Mã khách hàng
    [JsonProperty(PropertyName = "cusname")]
    public string customerId { get; set; }
    // Giá trị hàng hóa
    [JsonProperty(PropertyName = "goodsvalue")]
    public string total { get; set; }
    // COD
    [JsonProperty(PropertyName = "itemsvalue")]
    public string cod { get; set; }
    // Trọng lượng
    public string weight { get; set; }
    // Loại phí
    [JsonProperty(PropertyName = "feetype")]
    public string feeType { get; set; }
    // Loại vận chuyển
    [JsonProperty(PropertyName = "producttype")]
    public string productType { get; set; }
    // Thông tin người gửi
    public AddressFilterModel sender { get; set; }
    // Thông tin người nhận
    public AddressFilterModel receiver { get; set; }

    public string toJson()
    {
      var jObject = JObject.Parse(JsonConvert.SerializeObject(this));

      // Bỏ thuộc tính goodsvalue trường hợp giá trị sản phẩm dưới 3tr
      if (String.IsNullOrEmpty((string)jObject["goodsvalue"]))
        jObject.Property("goodsvalue").Remove();

      // Bỏ thuộc tính cod trường hợp không thu hộ
      if (String.IsNullOrEmpty((string)jObject["itemsvalue"]))
        jObject.Property("itemsvalue").Remove();

      return jObject.ToString();
    }

    #region Map
    public static FeeFilterModel map<T>(T source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<T, FeeFilterModel>()
      );

      var map = new Mapper(config);
      #endregion

      return map.Map<T, FeeFilterModel>(source);
    }
    #endregion
  }
}

