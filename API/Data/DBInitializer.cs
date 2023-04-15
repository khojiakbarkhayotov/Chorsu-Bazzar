using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public static class DBInitializer
    {
        public static void Initialize(StoreContext context){
            // close gate, if database context is filled then there is no need to insert something to it
            if(context.Products.Any()) return;

            // else do add something
            var products = new List<Product>{
                new Product{
                    Name = "Iphone X",
                    Description = "good choice",
                    Price = 20000,
                    pictureUrl = "something",
                    Type = "electronics",
                    Brand = "Apple",
                    QuantityInStock = 100,
                },
                new Product{
                    Name = "Iphone X",
                    Description = "good choice",
                    Price = 20000,
                    pictureUrl = "something",
                    Type = "electronics",
                    Brand = "Apple",
                    QuantityInStock = 100,
                },
            };
            
            // (134, "Iphone X", "good choice", 200, "something", "electronics", "Apple", 5);

            foreach(var product in products){
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}