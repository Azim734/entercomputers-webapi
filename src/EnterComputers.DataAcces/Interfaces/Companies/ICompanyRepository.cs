using EnterComputers.DataAcces.Common.Interfaces;
using EnterComputers.Domain.Entities.Companies;

namespace EnterComputers.DataAcces.Interfaces.Companies;

public interface ICompanyRepository : IRepository<Company, Company>,
    IGetAll<Company>
{
}
