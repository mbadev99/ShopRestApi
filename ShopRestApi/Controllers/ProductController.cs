using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopRestApi.Application.ProductDtos;
using ShopRestApi.Entities;
using ShopRestApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Add(AddProductDto dto)
        {
            _context.Products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Count = dto.Count,
                CreationDate = DateTime.Now
            });

            _context.SaveChanges();
        }

        [HttpGet]
        public List<GetProductDto> GetAll(string searchText = "")
        {
            return _context.Products.Where(_ => _.Name.ToLower().Contains(searchText.ToLower()))
                .Select(_ => new GetProductDto
                {
                    Name = _.Name,
                    Count = _.Count,
                    CreationDate = _.CreationDate.ToString(),
                    Id = _.Id
                }).ToList();
        }

        [HttpGet("detail")]
        public GetProductDto GetDetail(Guid id)
        {
            return _context.Products
                .Select(_ => new GetProductDto
                {
                    Name = _.Name,
                    Count = _.Count,
                    CreationDate = _.CreationDate.ToString(),
                    Id = _.Id
                }).Single(_ => _.Id == id);
        }

        [HttpPut("edit")]
        public void Edit(Guid id, EditProductDto dto)
        {
            var product = _context.Products.SingleOrDefault(_ => _.Id == id);
            NotFoundEx(product);
            product.Name = dto.Name;
            product.Count = dto.Count;

            _context.SaveChanges();
        }

        [HttpPatch("increase")]
        public void IncreaseCount(Guid id, IncreaseCountDto dto)
        {
            var product = _context.Products.SingleOrDefault(_ => _.Id == id);
            NotFoundEx(product);
            product.Count += dto.IncreaseCount;

            _context.SaveChanges();
        }

        [HttpDelete("delete")]
        public void Delete(Guid id)
        {
            var product = _context.Products.SingleOrDefault(_ => _.Id == id);
            NotFoundEx(product);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        private static void NotFoundEx(Product product)
        {
            if (product == null)
                throw new Exception("product not found!");
        }
    }
}
