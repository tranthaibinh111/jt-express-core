#region DotNet
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

using System.Resources;
#endregion

#region Package (third-party)
using RestSharp;
#endregion

#region Interfaces
using JtExpressCore.Interfaces.Services;
using JtExpressCore.Models.Common;
#endregion

namespace JtExpressCore.Services.Abstract
{
  public abstract class AbstractService : IService
  {
    #region Parameter
    protected readonly string companyId;
    protected readonly string token;

    protected RestClient _httpClient;
    #endregion

    #region Get
    public string env => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    /// <summary>
    /// https://docs.giaohangtietkiem.vn/?http#c-u-h-nh-chung
    /// </summary>
    public string domain
    {
      get
      {
        if (env == "Development")
          return "http://47.57.106.86/yuenan-interface-web";
        else
          return "http://sellapp.jtexpress.vn:22220/yuenan-interface-web";
      }
    }
    #endregion

    public AbstractService(string companyId, string token)
    {
      #region Token
      if (String.IsNullOrEmpty(companyId))
        throw new ArgumentException("Company ID registered the JT Express which can not be null or empty");

      this.companyId = companyId;
      #endregion

      #region Token
      if (String.IsNullOrEmpty(token))
        throw new ArgumentException("JT Express token can not be null or empty");

      this.token = token;
      #endregion

      _httpClient = new RestClient(domain);
    }

    ~AbstractService()
    {
      if (_httpClient != null)
        _httpClient.Dispose();
    }

    #region Private
    private string md5Hash(string value)
    {
      try
      {
        using var md5Provider = new MD5CryptoServiceProvider();
        var bytes = Encoding.UTF8.GetBytes(value);
        var hash = md5Provider.ComputeHash(bytes);
        var encode = BitConverter.ToString(hash)
          .Replace("-", String.Empty)
          .ToLower();

        return encode;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);

        throw;
      }
    }
    #endregion

    #region Protected
    public string encrypt(string value, string key)
    {
      try
      {
        var md5 = md5Hash(value + key);
        var bytes = Encoding.UTF8.GetBytes(md5);

        return Convert.ToBase64String(bytes);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);

        throw;
      }
    }

    /// <summary>
    /// Lấy thông tin lỗi trả về từ JT Express
    /// </summary>
    /// <param name="reason">Mã lỗi</param>
    /// <returns></returns>
    public string getErrMsg(string reason)
    {
      try
      {
        var errMsg = String.Empty;

        // Description
        var description = Descriptions.ResourceManager.GetString(reason);

        if (!String.IsNullOrEmpty(description)) errMsg += description;

        // Specific Occurrence
        var specificOccurrence = SpecificOccurrences.ResourceManager.GetString(reason);

        if (!String.IsNullOrEmpty(specificOccurrence)) errMsg += specificOccurrence;

        return errMsg;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);

        throw;
      }
    }
    #endregion
  }
}

