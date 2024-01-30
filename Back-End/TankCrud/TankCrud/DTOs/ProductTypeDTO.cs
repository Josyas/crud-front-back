using System.ComponentModel.DataAnnotations;

namespace TankCrud.DTOs
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}