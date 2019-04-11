using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caching.Models
{
            public class EmployeeViewModel
            {
            public EmployeeViewModel(int id1,int id2,string jobb , string name)
            {
            emp = new Employee() { Id = id2, fullName = name };
                emp.Id = id2;
                job = jobb;
            }
            public int Id { get; set; }
            public Employee emp { get; set; }
            public string  job { get; set; }
            }
            public class Employee
            {
                public int Id { get; set; }
                public string fullName { get; set; }
            }

}
