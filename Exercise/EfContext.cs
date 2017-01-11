using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    /// <summary>
    /// Id, ProductId, CustomerId, DateCreated
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
    }

    class EfContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }      
    }
}
