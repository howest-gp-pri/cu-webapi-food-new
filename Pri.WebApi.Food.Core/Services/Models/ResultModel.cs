namespace Pri.WebApi.Food.Core.Services.Models
{
    public class ResultModel<T> : BaseResult
    {
        public T Data { get; set; }
    }
}
