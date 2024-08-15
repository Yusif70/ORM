using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Exceptions.CustomerExceptions
{
	public class NoCustomersException : Exception
	{
		private static readonly string _message = "There are no customers on the system";
		public NoCustomersException() : base(_message) { }
		public NoCustomersException(string message) : base(message) { }
	}
}
