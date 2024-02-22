using Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppRevision.Models
{
    internal interface IRepo
    {
        Employee[] GetAllEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(WebAppRevision.Models.Employee employee);
        bool UpdateEmployee(WebAppRevision.Models.Employee employee);
        bool DeleteEmployee(WebAppRevision.Models.Employee employee);
       
    }
}

