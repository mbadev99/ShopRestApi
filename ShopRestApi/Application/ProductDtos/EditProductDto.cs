using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Application.ProductDtos
{
    public class EditProductDto : AddProductDto
    {
        public Guid Id { get; set; }
    }
}
