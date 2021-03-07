using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.Lab.Dal
{
    public class EmployeeRepository : Repository
    {
        public EmployeeRepository(IDbConnection connectnion, ISqlQueries sqlQueries) : base (connectnion, sqlQueries, nameof(EmployeeRepository))
        {
        }

        public async Task<IEnumerable<EmployeeDao>> GetAllAsync()
        {
            return await Connection.QueryAsync<EmployeeDao>(GetSqlQuery());
        }

        //zad 4
        public async Task<EmployeeDao> GetAsync(int id)
        {
            return await Connection.QueryFirstOrDefaultAsync<EmployeeDao>(GetSqlQuery(), new { par = id });
        }
        
        //zad 4
        public async Task<EmployeeDao> GetByCityAsync(string city)
        {
            return await Connection.QueryFirstOrDefaultAsync<EmployeeDao>(GetSqlQuery(), new { par = city });
        }

        private string GetWhereSQL()
        {
            return GetSqlQuery();
        }
    }
}
