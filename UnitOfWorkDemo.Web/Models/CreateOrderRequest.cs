using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Web.Models
{
    public class CreateOrderRequest
    {
        [Required]
        public int PersonId { get; set; }
        
        [Required]        
        public int ProductId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
    }
}
