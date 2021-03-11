using MangoWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Interfaces
{
    public interface IValuesService
    {
        Task<Values> Add(Values value);
        Task<IEnumerable<Values>> Get();
        Task<Values> GetById(int id);
        Task<bool> Update(int id, Values value);
        Task<bool> Delete(int id);
    }
}
