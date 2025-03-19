using System.Data;
using Dapper;

namespace Bootcamp.API.Repositories;

public class AccountRepository:IAccountRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public AccountRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }
    public async Task<bool> Deposit(int userId, decimal amount)
    {
        var sql1 = "update  accounts set price=price+@amount where id=@userId";

        return await _connection.ExecuteAsync(sql1, new { userId = userId, amount = amount }, transaction: _transaction) > 0;
    }
    public async Task<bool> Withdraw(int userId, decimal amount)
    {
        var sql1 = "update  accounts set price=price-@amount where id=@userId";

        return await _connection.ExecuteAsync(sql1, new { userId = userId, amount = amount }, transaction: _transaction) > 0;


    }
}