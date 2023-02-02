using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Data.Common;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Toolkit.Data;

public class Dapper : IDapper
{
    private readonly IConfiguration _config;
    private SqlConnection SqlConnection;
    public Dapper(IConfiguration config)
    {
        _config = config;

    }
    public void Dispose()
    {

    }


    public T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = GetDbconnection();
        return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
    }
    public async Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = GetDbconnection();
        var resut = await db.QueryAsync<T>(sp, parms, commandType: commandType);
        return resut.FirstOrDefault();
    }
    public List<T> GetAll<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = GetDbconnection();
        return db.Query<T>(sp, parms, commandType: commandType).ToList();
    }

    public async Task<List<T>> GetAllAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = GetDbconnection();
        var result = await db.QueryAsync<T>(sp, parms, commandType: commandType);
        return result.ToList();
    }
    public DbConnection GetDbconnection()
    {
        SqlConnection = new SqlConnection(_config.GetConnectionString("DapperCnn"));
        if (SqlConnection.State != ConnectionState.Open)
            SqlConnection.Open();
        return SqlConnection;
    }



}
