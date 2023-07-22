namespace EnterComputers.DataAcces.Interfaces;

public interface IRepository<Tentity, TViewModel>
{
    public Task<int> CreateAsync(Tentity entity);

    public Task<int> UpdateAsync(long id, Tentity entity);

    public Task<int> DeleteAsync(long id);

    public Task<TViewModel?> GetByIdAsync(long id);

    public Task<long> CountAsync();
}
