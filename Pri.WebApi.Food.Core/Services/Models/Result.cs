namespace Pri.WebApi.Food.Core.Services.Models
{
    public class Result
    {
        public bool Success => !Errors.Any();
        public List<string> Errors { get; set; } = new List<string>();
    }
}
