using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Food.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
