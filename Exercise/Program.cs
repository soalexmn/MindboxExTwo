using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                //init
                context.Sales.RemoveRange(context.Sales);
                context.SaveChanges();
                context.Sales.Add(new Sale { ProductId = 1, CustomerId = 1, DateCreated = DateTime.Now.AddDays(-1) });
                context.Sales.Add(new Sale { ProductId = 1, CustomerId = 2, DateCreated = DateTime.Now.AddDays(-1) });
                context.Sales.Add(new Sale { ProductId = 1, CustomerId = 3, DateCreated = DateTime.Now.AddDays(-1) });
                context.Sales.Add(new Sale { ProductId = 2, CustomerId = 4, DateCreated = DateTime.Now.AddDays(-1) });
                context.Sales.Add(new Sale { ProductId = 2, CustomerId = 1, DateCreated = DateTime.Now });
                context.Sales.Add(new Sale { ProductId = 3, CustomerId = 1, DateCreated = DateTime.Now });
                context.SaveChanges();
                context.Database.Log = str => System.Diagnostics.Debug.WriteLine(str);



                var result = context.Sales.OrderByDescending(s => s.DateCreated)
                     .GroupBy(s => s.CustomerId)
                     .Select(custGroup => custGroup.OrderBy(v => v.DateCreated).FirstOrDefault())
                     .GroupBy(s => s.ProductId)
                     .Select(group => new { ProductId = group.Key, Count = group.Count() })
                     .ToArray();

            }
        }
    }
}
