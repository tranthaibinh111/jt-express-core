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
    public string cusname { get; set; }
    // Giá trị hàng hóa
    public string goodsvalue { get; set; }
    // COD
    public string itemsvalue { get; set; }
    // Trọng lượng
    public string weight { get; set; }
    // Phường xã nhận
    public string destareacode { get; set; }
    // Quận huyện gửi
    public string sendsitecode { get; set; }
    // Loại phí
    public string feetype { get; set; }
    // Loại vận chuyển
    public string producttype { get; set; }

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

