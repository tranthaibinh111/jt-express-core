#region DotNet
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

#region Package (third-party)
using RestSharp;
using Newtonsoft.Json;
#endregion

#region Interface
using JtExpressCore.Interfaces.Services;
#endregion

#region Utils
using JtExpressCore.Utils;
#endregion

#region Common
// Interfaces
using JtExpressCore.Interfaces.Models.Common;

// Models
using JtExpressCore.Models.Common;
#endregion

#region JT Express
// Models
using JtExpressCore.Models.JtExpress;

// Service
using JtExpressCore.Services.Abstract;
#endregion

namespace JtExpressCore.Services.Ghtk
{
  public sealed class FeeService: AbstractService
  {
    public FeeService(string companyId, string token) : base(companyId, token) {}

    #region Public
    /// <summary>
    /// Tính phí JT Express
    ///
    /// https://api-docs.jtexpress.vn/api/api-4/
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<IResponseModel> getFee(FeeFilterModel filter)
    {
      try
      {
        #region Thiết lập API JT Express
        var url = "standard/inquiry!newFreight.action";
        var json = filter.toJson();
        var request = new RestRequest(url, Method.Post);


        request.AlwaysMultipartFormData = true;
        request.AddParameter("logistics_interface", json);
        request.AddParameter("data_digest", encrypt(json, token));
        request.AddParameter("msg_type", "FREIGHTQUERY");
        request.AddParameter("eccompanyid", companyId);
        #endregion

        #region Thực thi API KiotViet
        var restResp = await _httpClient.ExecuteAsync(request);

        //Trường hợp lỗi xãy ra với API phí của JT Express
        if (restResp.StatusCode != HttpStatusCode.OK)
          return new ErrorModel("Thất bại! Lỗi xãy ra với API phí của JT Express");

        var parsed = restResp.Content;
        var resp = ResponseModel<FeeModel>.map(parsed);

        if (!resp.success)
        {
          var errMsg = getErrMsg(resp.reason);

          return new ErrorModel(errMsg);
        }
        #endregion

        // Tổng hợp dữ liệu
        var result = new SuccessModel<FeeModel>(resp.data);

        return result;
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

