using MangoWebApi.Repositories.Interfaces;
using MangoWebApi.Repositories.Interfaces.Repositories;

namespace MangoWebApi.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository,
                  IAttributeRepository attributeRepository,
                  ICategoryRepository categoryRepository,
             IValueRepository valueRepository)
        {
            ProductRepository = productRepository;
            AttributeRepository = attributeRepository;
            CategoryRepository = categoryRepository;
            ValueRepository = valueRepository;
        }

        public IProductRepository ProductRepository { get; }

        public IValueRepository ValueRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IAttributeRepository AttributeRepository { get; }
    }
}
