using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Categories> Add(Categories categories)
        {
            return await _unitOfWork.CategoryRepository.Add(categories);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.CategoryRepository.Delete(id);
        }

        public async Task<IEnumerable<Categories>> Get()
        {
            return await _unitOfWork.CategoryRepository.Get();
        }

        public async Task<Categories> GetById(int id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }

        public async Task<bool> Update(int id, Categories categories)
        {
            return await _unitOfWork.CategoryRepository.Update(id, categories);
        }
    }
}
