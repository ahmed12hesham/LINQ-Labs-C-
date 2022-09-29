using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------Ahmed_hesham-----------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------------------------Array--------------------------------");
            Console.WriteLine();
            Employee[] employees =
            {
              new Employee {Name="Ahmed",Id=1,Salary="3000",dept=5,Job_title="SW"},
              new Employee {Name="hesham",Id=2,Salary="4000",dept=3,Job_title="HW"},
              new Employee {Name="assem",Id=3,Salary="7000",dept=4,Job_title="Manager"},
              new Employee {Name="mohamed",Id=4,Salary="1000",dept=5,Job_title="SW"},
              new Employee {Name="moaz",Id=5,Salary="2000",dept=2,Job_title="IT"}
            };
            var query1 = from Employee employee in employees
                         where employee.dept == 2
                         select employee;
            foreach (Employee m in query1)
            {
                Console.WriteLine("Using List dept : " + m.Name + " ( " + m.Id + " ) " + ": " + m.Salary);
            }
            var query2 = from Employee employee in employees
                         where employee.Job_title == "SW"
                         select employee;
            foreach (Employee m in query2)
            {
                Console.WriteLine("Using List Job_title : " + m.Name + " ( " + m.Id + " ) " + ": " + m.Salary);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("---------------------------------List---------------------------------");
            Console.WriteLine();
            List<Employee> employe = new List<Employee>{
              new Employee {Name="Ahmed",Id=1,Salary="3000",dept=5,Job_title="SW"},
              new Employee {Name="hesham",Id=2,Salary="4000",dept=3,Job_title="HW"},
              new Employee {Name="assem",Id=3,Salary="7000",dept=4,Job_title="Manager"},
              new Employee {Name="mohamed",Id=4,Salary="1000",dept=5,Job_title="SW"},
              new Employee {Name="moaz",Id=5,Salary="2000",dept=2,Job_title="IT"}
            };
            var query3 = from Employee employee in employe
                        where employee.dept == 3
                         select employee;
            foreach (Employee e in query3)
            {
                Console.WriteLine("Using List dept : " + e.Name + " ( " + e.Id + " ) " + ": " + e.Salary);
            }
            var query4 = from Employee employee in employe
                         where employee.Job_title == "Manager"
                         select employee;
            foreach (Employee e in query4)
            {
                Console.WriteLine("Using List jobtitle : " + e.Name + " ( " + e.Id + " ) " + ": " + e.Salary);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("--------------------------------Array_List---------------------------------");
            Console.WriteLine();
            ArrayList emp = new ArrayList()
            {
              new Employee {Name="ahmed",Id=1,Salary="3000",dept=5,Job_title="SW"},
              new Employee {Name="hesham",Id=2,Salary="4000",dept=3,Job_title="HW"},
              new Employee {Name="assem",Id=3,Salary="7000",dept=4,Job_title="Manager"},
              new Employee {Name="mohamed",Id=4,Salary="1000",dept=5,Job_title="SW"},
              new Employee {Name="moaz",Id=5,Salary="2000",dept=2,Job_title="IT"}
            };
            var query5 = from Employee employee in emp
                        where employee.dept == 5
                        select employee;
            foreach (Employee s in query5)
                Console.WriteLine("Using ArrayList dept : " + s.Name + " ( " + s.Id + " ) " + ": " + s.Salary);
            var query6 = from Employee employee in emp
                        where employee.Job_title == "IT"
                        select employee;
            foreach (Employee s in query6)
                Console.WriteLine("Using ArrayList Job_title : " + s.Name + " ( " + s.Id + " ) " + ": " + s.Salary);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.ReadKey();
        }
       
    }
}
