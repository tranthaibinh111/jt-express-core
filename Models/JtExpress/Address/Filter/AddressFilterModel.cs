#region DotNet
using System;
#endregion

#region Package (third-party)
using AutoMapper;
#endregion

#region JT Express
// Models
using JtExpressCore.Models.Abstract;
#endregion

namespace JtExpressCore.Models.JtExpress
{
  public class AddressFilterModel : AbstractPersonalModel
  {
    #region Map
    public static AddressFilterModel map(PersonalModel source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<PersonalModel, AddressFilterModel>()
      );
      var map = new Mapper(config);
      #endregion

      return map.Map<PersonalModel, AddressFilterModel>(source);
    }

    public static AddressFilterModel map<T>(T source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<T, AddressFilterModel>()
      );
      var map = new Mapper(config);
      #endregion

      return map.Map<T, AddressFilterModel>(source);
    }
    #endregion
  }
}

