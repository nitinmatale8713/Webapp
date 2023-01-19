using SqlApp.Model;

namespace SqlApp.Service.Abstract
{
    public interface IEmployee
    {
        public List<Employee> GetEmployees();
    }
}
