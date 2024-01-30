using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TankCrud.Entities;

namespace TankCrud.Models
{
    public class ProductType : Base
    {
        public string Name { get; set; }
        [NotMapped]
        public List<Tank> Tanks { get; set; } 
    }
}