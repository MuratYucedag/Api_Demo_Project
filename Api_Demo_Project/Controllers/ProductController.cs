using Api_Demo_Project.DAL.Context;
using Api_Demo_Project.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        CategoryContext context = new CategoryContext();

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = context.Products.Find(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values = context.Products.Find(id);
            context.Products.Remove(values);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var values = context.Products.Find(product.ProductID);
            values.ProductName = product.ProductName;
            values.ProductStatatus = product.ProductStatatus;
            values.ProductStock = product.ProductStock;
            context.SaveChanges();
            return Ok();
        }
    }
}
