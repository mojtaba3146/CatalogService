namespace Category.Domain.CommanInterfaces
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Rollback();
        Task CommitPartial();
        Task Complete();
    }
}
