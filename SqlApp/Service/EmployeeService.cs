using SqlApp.Model;
using SqlApp.Service.Abstract;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace SqlApp.Service
{
    public class EmployeeService : IEmployee
    {
        private string db_dataSource = "dabaseserver.database.windows.net";
        private string db_userId = "sqladmin";
        private string db_password = "Pass@1387";
        private string db_database = "appdb";
        public List<Employee> GetEmployees()
        {
            SqlConnection sqlCon = GetConnection();
            List<Employee > employees = new List<Employee>();
            string query = "select * from Employee";
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand(query,sqlCon);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Employee emp = new Employee()
                {
                    ID = Convert.ToInt32(reader.GetValue(0)),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Country = reader.GetString(3)
                };
                employees.Add(emp);
            }
            return employees;
        }
        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_dataSource;
            _builder.UserID = db_userId;
            _builder.Password = db_password;
            _builder.InitialCatalog=db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

    }
}
