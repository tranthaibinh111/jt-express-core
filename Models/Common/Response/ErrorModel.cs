#region DotNet
using System;
using System.Collections.Generic;
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
  /// Error Response
  /// { 'success': true, 'message': '' }
  /// </summary>
  public class ErrorModel : IResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }

    public ErrorModel()
    {
      success = false;
    }

    public ErrorModel(string message): this()
    {
      this.message = message;
    }
  }
}

