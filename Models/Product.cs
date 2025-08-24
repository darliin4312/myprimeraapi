using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimerAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; } 

        [Precision(18, 2)]   // Precisión para SQL Server
        public decimal Price { get; set; }
    }
}
