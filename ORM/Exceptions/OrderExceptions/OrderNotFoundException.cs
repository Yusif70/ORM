using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Exceptions.OrderExceptions
{
	public class OrderNotFoundException : Exception
	{
		private static readonly string _message = "Order not found";
		public OrderNotFoundException() : base(_message) { }
		public OrderNotFoundException(string message) : base(message) { }
	}
}
