#region DotNet
using System;
#endregion

namespace JtExpressCore.Interfaces.Services
{
  public interface IService
  {
    string env { get; }
    string domain { get; }
  }
}

