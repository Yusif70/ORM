using ORM.CodeFirst;
using ORM.Entities;
using ORM.Exceptions.CustomerExceptions;

namespace ORM.Services
{
	public class CustomerService
	{
		private readonly TestDBContext context = new();
		public void Add(Customer customer)
		{
			context.Add(customer);
			context.SaveChanges();
		}
		public void Update(int id, string newContactName)
		{
			Customer customer = Get(id);
			customer.ContactName = newContactName;
			context.Update(customer);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Customer customer = Get(id);
			context.Remove(customer);
			context.SaveChanges();
		}
		public List<Customer> GetAll()
		{
			List<Customer> customers = [.. context.Customers];
			if (customers.Count > 0)
			{
				return customers;
			}
			else
			{
				throw new NoCustomersException("sistemde musteri yoxdur");
			}
		}
		public Customer Get(int id)
		{
			Customer? customer = GetAll().Find(customer => customer.CustomerId == id);
			if (customer != null)
			{
				return customer;
			}
			else
			{
				throw new CustomerNotFoundException("musteri tapilmadi");
			}
		}
	}
}
