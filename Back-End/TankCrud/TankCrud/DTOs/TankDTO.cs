using System.ComponentModel.DataAnnotations;

namespace TankCrud.DTOs
{
    public class TankDTO
    {
        public int Id { get; set; }
        [Required]
        public string Deposit { get; set; }
        [Required]
        public string Capacity { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
    }
}