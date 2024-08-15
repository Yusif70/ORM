using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Exceptions.EmployeeExceptions
{
	public class NoEmployeesException : Exception
	{
		private static readonly string _message = "There are no employees on the system";
		public NoEmployeesException() : base(_message) { }
		public NoEmployeesException(string message) : base(message) { }
	}
}
