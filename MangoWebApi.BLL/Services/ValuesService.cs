using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValuesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Values> Add(Values value)
        {
            return await _unitOfWork.ValueRepository.Add(value);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.ValueRepository.Delete(id);
        }

        public async Task<IEnumerable<Values>> Get()
        {
            return await _unitOfWork.ValueRepository.Get();
        }

        public async Task<Values> GetById(int id)
        {
            return await _unitOfWork.ValueRepository.GetById(id);
        }

        public async Task<bool> Update(int id, Values value)
        {
            return await _unitOfWork.ValueRepository.Update(id, value);
        }
    }
}
