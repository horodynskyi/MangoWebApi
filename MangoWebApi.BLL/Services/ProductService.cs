using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Services
{
    public class ProductService:IProductService
    {
        IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _unitOfWork.ProductRepository.Add(product);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _unitOfWork.ProductRepository.Get();
        }

        public async Task<Product> GetById(int id)
        {
          
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task<bool> Update(int id,Product product)
        {
            return await _unitOfWork.ProductRepository.Update(id, product);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.ProductRepository.Delete(id);
        }
    }
}
