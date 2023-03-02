#region DotNet
using System;
#endregion

#region Common
// Interfaces
using JtExpressCore.Interfaces.Models.Common;
#endregion

#region GHTK
// Models
using JtExpressCore.Models.JtExpress;
#endregion

namespace JtExpressCore.Models.Common
{
  /// <summary>
  /// Success Response
  /// { 'success': true, 'message': '', data: {} }
  /// </summary>
  public class SuccessModel<T> : IResponseModel
  {
    public bool success { get; set; }
    public T data { get; set; }

    public SuccessModel(T data)
    {
      success = true;
      this.data = data;
    }
  }
}

