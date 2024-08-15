using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Exceptions.EmployeeExceptions
{
	public class EmployeeNotFoundException : Exception
	{
		private static readonly string _message = "Employee not found";
		public EmployeeNotFoundException() : base(_message) { }
		public EmployeeNotFoundException(string message) : base(message) { }
	}
}
