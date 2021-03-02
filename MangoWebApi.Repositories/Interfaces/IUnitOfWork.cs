using MangoWebApi.Repositories.Interfaces.Repositories;
using MangoWebApi.Repositories.Repositories;

namespace MangoWebApi.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IValueRepository ValueRepository { get; }
        IAttributeRepository AttributeRepository { get; }

    }
}
