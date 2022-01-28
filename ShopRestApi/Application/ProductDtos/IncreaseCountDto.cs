using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Application.ProductDtos
{
    public class IncreaseCountDto
    {
        public Guid Id { get; set; }
        public int IncreaseCount { get; set; }
    }
}
