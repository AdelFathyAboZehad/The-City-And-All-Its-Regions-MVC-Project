namespace Task4Linkerp.Models.Srvices
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity Create(TEntity item);
        bool Update(TEntity item);
        bool Delete(int id);
        Task<IEnumerable<TEntity>> FilterByAsync(string? filter = null, int? code = null);
    }
}
