using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dal
{
    //ORM
    public class Employee
    {
        public int Eid { get; set; }
        public string EName { get; set; }
        public int EDept { get; set; }
    }

    public interface IDal
    {
        Employee[] GetAll();
        Employee GetEmpById(int id);
        bool ModifyEmp(Employee emp);
        bool AddEmp(Employee emp);
        bool DeleteEmp(int id);
    }
    public static class DalFactrory
    {
        public static IDal GetDalInstance(string cnnstr)
        {
            return new CDal(cnnstr);
        }
    }

    internal class CDal : IDal
    {
        private readonly string cnnstr;
        SqlConnection connection;
        SqlCommand command;
        public CDal(string cnnstr)
        {
            this.cnnstr = cnnstr;
            connection = new SqlConnection(cnnstr);
            command = connection.CreateCommand();
        }
        public Employee[] GetAll()
        {
            string query = "select * from Employee";
            List<Employee> employees= DoQuery(query);
            return employees.ToArray();
        }

        public Employee GetEmpById(int id)
        {
            string query = $"select * from Employee where EmpId={id} ";
            List<Employee> employees = DoQuery(query);
            return employees.FirstOrDefault();
        }
       
        public bool AddEmp(Employee emp)
        {
            string query = $"insert into employee values({emp.Eid},'{emp.EName}',{emp.EDept})";
            return DoNonQuery(query);
        }

        public bool DeleteEmp(int id)
        {
            string query = $"delete from employee where EmpId={id}";
            return DoNonQuery(query);
        }

        public bool ModifyEmp(Employee emp)
        {
            string query = $"update employee set EmpName='{emp.EName}',EmpDept={emp.EDept} where EmpId={emp.Eid}";
            return DoNonQuery(query);
        }

        private bool DoNonQuery(string query)
        {
            command.CommandText = query;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        private List<Employee> DoQuery(string query)
        {
            List<Employee> employees = new List<Employee>();
            command.CommandText = query;
            connection.Open();
            SqlDataReader reader=command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while(reader.Read())
            {
                employees.Add(new Employee { Eid = (int)reader[0], EName = reader[1].ToString(), EDept = (int)reader[2] });
            }
            reader.Close();
            return employees;

        }
    }
}
