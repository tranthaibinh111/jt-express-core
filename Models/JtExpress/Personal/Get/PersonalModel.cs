#region Package (third-party)
using AutoMapper;
#endregion

#region JT Express
// Interface
using JtExpressCore.Interfaces.Models.JtExpress;

// Models
using JtExpressCore.Models.Abstract;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  public class PersonalModel: AbstractPersonalModel
  {
    public string companyId { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string tel { get; set; }
  }
}

