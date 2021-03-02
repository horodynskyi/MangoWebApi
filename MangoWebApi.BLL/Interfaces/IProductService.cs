using MangoWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> Get();
        Task<Product> GetById(int id);
        Task<bool> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}
