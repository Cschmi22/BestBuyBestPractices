﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepositiry
    {

        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }
        public void InsertDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name);", new {name = name});
        }
    }
}
