using EF_Demo1;
using System;
using System.Linq;
using System.Web.UI;

namespace EF_Demo1
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Employee1Entities db = new Employee1Entities())
            {
                var data = db.Employees.Select(emp => new
                {
                    emp.FirstName,
                    emp.LastName,
                    emp.Gender,
                    emp.Salary,
                    DeptName = emp.Department.Name
                }).ToList();
                foreach (var item in data)
                {
                    Response.Write("Name: " + item.FirstName + " " + item.LastName + "<br/>");
                    Response.Write("Gender: " + item.Gender + "<br/>");
                    Response.Write("Salary: " + item.Salary + "<br/>");
                    Response.Write("Department: " + item.DeptName + "<br/><br/>");
                }
            }
        }
    }
}