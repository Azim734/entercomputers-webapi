using EnterComputers.DataAcces.Common.Interfaces;
using EnterComputers.DataAcces.ViewModels.Products;
using EnterComputers.Domain.Entities.Products;

namespace EnterComputers.DataAcces.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
}
