namespace JtExpressCore.Interfaces.Models.Common
{
  public interface IResponseItemModel: IResponseModel
  {
    string reason { get; set; }
  }
}
