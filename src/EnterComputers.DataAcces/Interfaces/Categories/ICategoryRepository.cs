using EnterComputers.DataAcces.Common.Interfaces;
using EnterComputers.Domain.Entities.Categories;

namespace EnterComputers.DataAcces.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{
}
