using Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAppRevision.Models
{
    public  class ActualRepo: IRepo
    {
        private  readonly string cnnstr;
        private  IDal dal;
        public  ActualRepo()
        {
            cnnstr = ConfigurationManager.ConnectionStrings["cnnstr"].ConnectionString;
            dal=DalFactrory.GetDalInstance(cnnstr);
        }
        public  Employee[] GetAllEmployees()
        {
            var employees=from emp in  dal.GetAll() select new WebAppRevision.Models.Employee { Id=emp.Eid, Name=emp.EName, Did=emp.EDept };
            return employees.ToArray();
        }
        public  Employee GetEmployee(int id)
        {
            var emp =dal.GetEmpById(id); 
            return new WebAppRevision.Models.Employee { Id = emp.Eid, Name = emp.EName, Did = emp.EDept };
        }
        public  bool AddEmployee(WebAppRevision.Models.Employee employee)
        {
            return dal.AddEmp(new Dal.Employee { Eid = employee.Id, EName = employee.Name, EDept = employee.Did });
        }
        public  bool UpdateEmployee(WebAppRevision.Models.Employee employee)
        {
            return dal.ModifyEmp(new Dal.Employee { Eid = employee.Id, EName = employee.Name, EDept = employee.Did });
        }
        public  bool DeleteEmployee(WebAppRevision.Models.Employee employee)
        {
            return dal.DeleteEmp(employee.Id);
        }
    }
}