using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp.Model;
using SqlApp.Service;

namespace SqlApp.Pages
{
    public class IndexModel : PageModel
    {
        EmployeeService employeeservice = new EmployeeService();
        public List<Employee> emp_lst= new List<Employee>();

        public void OnGet()
        {
            emp_lst= employeeservice.GetEmployees();

        }
    }
}