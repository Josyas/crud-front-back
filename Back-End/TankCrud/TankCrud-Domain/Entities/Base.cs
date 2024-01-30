using System.ComponentModel.DataAnnotations.Schema;

namespace TankCrud.Entities
{
    [NotMapped]
    public abstract class Base
    {
        public int Id { get; set; }
    }
}