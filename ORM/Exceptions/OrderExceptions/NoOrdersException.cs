using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Exceptions.OrderExceptions
{
	public class NoOrdersException : Exception
	{
		private static readonly string _message = "There are no orders on the system";
		public NoOrdersException() : base(_message) { }
		public NoOrdersException(string message) : base(message) { }
	}
}
