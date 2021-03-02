using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using MangoWebApi.Repositories.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttributeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Attribute> Add(Attribute attribute)
        {
            return await _unitOfWork.AttributeRepository.Add(attribute);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.AttributeRepository.Delete(id);
        }

        public async Task<IEnumerable<Attribute>> Get()
        {
            return await _unitOfWork.AttributeRepository.Get();
        }

        public async Task<Attribute> GetById(int id)
        {
            return await _unitOfWork.AttributeRepository.GetById(id);
        }

        public async Task<bool> Update(int id, Attribute attribute)
        {
            return await _unitOfWork.AttributeRepository.Update(id, attribute);
        }
    }
}
