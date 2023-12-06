using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StarTedSystem.DAL;
using StarTedSystem.Entities;

namespace StarTedSystem.BLL
{
    public class EmployeeServices
    {
        private readonly StarTedContext _context;

        internal EmployeeServices(StarTedContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Return all employees in the system.
        /// </summary>
        /// <returns>A list of employees, if any were found.</returns>
        public List<Employee>? GetEmployees()
        {
            return _context.Employees.ToList<Employee>();
        }
    }
}
