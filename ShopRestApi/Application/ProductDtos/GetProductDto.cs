using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Application.ProductDtos
{
    public class GetProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string CreationDate { get; set; }
    }
}
