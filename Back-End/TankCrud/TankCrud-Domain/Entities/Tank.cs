using System.ComponentModel.DataAnnotations.Schema;
using TankCrud.Entities;

namespace TankCrud.Models
{
    public class Tank : Base
    {
        public string Deposit { get; set; }
        public string Capacity { get; set;}
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}