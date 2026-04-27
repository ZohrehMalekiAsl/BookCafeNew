namespace BookCafe.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveAysnc();
        Task BeginTransaction();
        Task RollbackTransaction();
        Task DisposeTransaction();
        Task CommitTransaction();
    }
}
