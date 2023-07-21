using EnterComputers.DataAcces.Utils;

namespace EnterComputers.DataAcces.Common.Interfaces;

public interface IGetAll<Tmodel>
{
    public Task<IList<Tmodel>> GetAllAsync(PaginationParams @params);
}
