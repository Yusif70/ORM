using ORM.CodeFirst;
using ORM.Entities;
using ORM.Exceptions.OrderExceptions;

namespace ORM.Services
{
	public class OrderService
	{
		private readonly TestDBContext context = new();
		public void Add(Order order)
		{
			context.Add(order);
			context.SaveChanges();
		}
		public void Update(int id)
		{
			Order? order = Get(id);
			context.Update(order);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Order? order = Get(id);
			context.Remove(order);
			context.SaveChanges();
		}
		public List<Order> GetAll()
		{
			List<Order> orders = [.. context.Orders];
			if (orders.Count > 0)
			{
				return orders;
			}
			else
			{
				throw new NoOrdersException("sistemde sifaris yoxdur");
			}
		}
		public Order? Get(int id)
		{
			Order? order = GetAll().Find(order => order.OrderId == id);
			if (order != null)
			{
				return order;
			}
			else
			{
				throw new OrderNotFoundException("sifaris tapilmadi");
			}
		}
	}
}
