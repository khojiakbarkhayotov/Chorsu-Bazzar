using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        // public ActionResult<List<Product>> GetProducts(){
        //     var products = context.Products.ToList();

        //     return Ok(products);
        // }

        // async alternative
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await context.Products.FindAsync(id);

            return Ok(product);
        }
    }
}