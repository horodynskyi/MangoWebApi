using MangoWebApi.Repositories.Interfaces;
using MangoWebApi.Repositories.Interfaces.Repositories;
using MangoWebApi.Repositories.Repositories;

namespace MangoWebApi.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValueRepository _valueRepository;
           public UnitOfWork(IProductRepository productRepository,
                  IAttributeRepository attributeRepository,
                  ICategoryRepository categoryRepository,
             IValueRepository valueRepository)
        {
            _productRepository = productRepository;
            _attributeRepository = attributeRepository;
            _categoryRepository = categoryRepository;
            _valueRepository = valueRepository;
        }

        public IProductRepository ProductRepository
        {
            get
            {
               return _productRepository;
            }
        }
        public IValueRepository ValueRepository
        {
            get
            {
                return _valueRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository;
            }
        }

        public IAttributeRepository AttributeRepository
        {
            get
            {
                return _attributeRepository;
            }
        }
    }
}
