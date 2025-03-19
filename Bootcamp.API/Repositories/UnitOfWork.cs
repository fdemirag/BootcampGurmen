using System.Data;

namespace Bootcamp.API.Repositories;

public class UnitOfWork
{
    private readonly IDbTransaction _transaction;

    public UnitOfWork(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public void Commit()
    {

        _transaction.Commit();
    }
    public void Rollback()
    {

        _transaction.Rollback();
    }
}