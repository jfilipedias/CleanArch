namespace CleanArch.Domain;

public interface IUnitOfWork
{
    Task Begin();
    Task Commit();
    Task Rollback();
}
