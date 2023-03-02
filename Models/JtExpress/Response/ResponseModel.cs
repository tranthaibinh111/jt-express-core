#region DotNet
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region JT Express
using JtExpressCore.Interfaces.Models.Common;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  public class ResponseModel<T> where T : IResponseItemModel
  {
    [JsonProperty(PropertyName = "logisticproviderid")]
    public string logisticProviderId { get; set; }
    [JsonProperty(PropertyName = "responseitems")]
    public IList<T> responseItems { get; set; }

    public bool success {
      get
      {
        var status = responseItems.First();

        return status.success;
      }
    }

    public string reason
    {
      get
      {
        var resp = responseItems.First();

        return resp.reason;
      }
    }

    public T data
    {
      get
      {
        var resp = responseItems.First();

        return resp;
      }
    }

    #region Map
    public static ResponseModel<T> map(string json) =>
      JsonConvert.DeserializeObject<ResponseModel<T>>(json);
    #endregion
  }
}

