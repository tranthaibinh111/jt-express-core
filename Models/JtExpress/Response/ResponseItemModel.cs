#region JT Express
using JtExpressCore.Interfaces.Models.Common;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  public class ResponseItemModel: IResponseItemModel
  {
    public bool success { get; set; }
    public string reason { get; set; }
  }
}

