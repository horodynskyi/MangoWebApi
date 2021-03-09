using MangoWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Interfaces
{
    public interface IAttributeService
    {
        Task<Attribute> Add(Attribute attribute);
        Task<IEnumerable<Attribute>> Get();
        Task<Attribute> GetById(int id);
        Task<bool> Update(int id, Attribute attribute);
        Task<bool> Delete(int id);
    }
}
