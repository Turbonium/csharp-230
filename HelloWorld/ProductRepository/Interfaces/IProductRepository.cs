using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}