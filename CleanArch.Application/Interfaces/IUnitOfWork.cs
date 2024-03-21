namespace CleanArch.Application;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
