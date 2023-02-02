using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Toolkit.Data;


public interface IDapper : IDisposable
{
    T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text);
    Task<T> GetAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text);
    List<T> GetAll<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text);
    Task<List<T>> GetAllAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text);

}

