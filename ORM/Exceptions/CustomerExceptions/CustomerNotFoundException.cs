namespace ORM.Exceptions.CustomerExceptions
{
	public class CustomerNotFoundException : Exception
	{
		private static readonly string _message = "Employee not found";
		public CustomerNotFoundException() : base(_message) { }
		public CustomerNotFoundException(string message) : base(message) { }
	}
}
