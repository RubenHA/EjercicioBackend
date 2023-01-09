using EjercicioBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioBackend.Repositories
{
    interface IProductCollection
    {
        Task InsertProduct(Product producto);
        Task UpdateProduct(Product producto);
        Task DeleteProduct(string id);

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
    }
}
