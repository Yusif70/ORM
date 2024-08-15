using Azure.Identity;
using ORM.Entities;
using ORM.Exceptions.CustomerExceptions;
using ORM.Exceptions.EmployeeExceptions;
using ORM.Exceptions.OperationExceptions;
using ORM.Services;

namespace Ado.Net.Menu
{
	public class Menu
	{
		private static readonly string menu = "\t1.Customer Menu\n" +
		"\t2.Employee Menu\n" +
			"\t3.Order Menu\n" +
		"\t0.Exit\n";
		private static readonly string customerMenu = "\t1.Customer Add\n" +
				"\t2.Customer Update\n" +
				"\t3.Customer Remove\n" +
				"\t4.Get All Customers\n" +
				"\t0.Exit\n";
		private static readonly string employeeMenu = "\t1.Employee Add\n" +
					"\t2.Employee Update\n" +
					"\t3.Employee Remove\n" +
					"\t4.Get All Employees\n" +
					"\t0.Exit\n";
		private static readonly string orderMenu = "\t1.Order Add\n" +
			"\t2.Order Remove\n" +
			"\t3.Get All Orders\n" +
			"\t0.Exit\n";
		public static void MainMenu()
		{
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(menu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								CustomerMenu();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								EmployeeMenu();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								OrderMenu();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 0:
							loop = false;
							break;
						default:
							throw new OperationNotFoundException("emeliyyat tapilmadi");
					}
				}
				catch (OperationNotFoundException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		private static void CustomerMenu()
		{
			CustomerService customerService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(customerMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								Console.Write("ad soyad: ");
								string? contactName = Console.ReadLine()?.Trim();
								Console.Write("olke: ");
								string? country = Console.ReadLine()?.Trim();
								Console.Write("seher: ");
								string? city = Console.ReadLine()?.Trim();
								if (!string.IsNullOrEmpty(contactName) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
								{
									Customer customer = new()
									{
										ContactName = contactName,
										City = city,
										Country = country
									};
									customerService.Add(customer);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								List<Customer> customers = customerService.GetAll();
								foreach (Customer customer in customers)
								{
									Console.WriteLine($"{customer.CustomerId}) {customer.ContactName} {customer.City} {customer.Country}");
								}
								Console.Write("musteri idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int customerId);
								Customer customer1 = customerService.Get(customerId);
								Console.WriteLine($"kohne ad soyad: {customer1.ContactName}");
								Console.Write("yeni ad soyad: ");
								string? newContactName = Console.ReadLine()?.Trim();
								if (!string.IsNullOrEmpty(newContactName))
								{
									customerService.Update(customerId, newContactName);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								List<Customer> customers = customerService.GetAll();
								foreach (Customer customer in customers)
								{
									Console.WriteLine($"{customer.CustomerId}) {customer.ContactName} {customer.City} {customer.Country}");
								}
								Console.Write("musteri idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int customerId);
								customerService.Delete(customerId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 4:
							try
							{
								List<Customer> customers = customerService.GetAll();
								foreach (Customer customer in customers)
								{
									Console.WriteLine($"{customer.CustomerId}) {customer.ContactName} {customer.City} {customer.Country}");
								}
							}
							catch (NoCustomersException ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 0:
							loop = false;
							break;
						default:
							throw new OperationNotFoundException("emeliyyat tapilmadi");
					}
				}
				catch (OperationNotFoundException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		private static void EmployeeMenu()
		{
			EmployeeService employeeService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(employeeMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								Console.Write("ad: ");
								string? firstName = Console.ReadLine()?.Trim();
								Console.Write("soyad: ");
								string? lastName = Console.ReadLine()?.Trim();
								Console.Write("vezife: ");
								string? title = Console.ReadLine()?.Trim();
								Console.Write("ise alinma tarixi: ");
								DateOnly.TryParse(Console.ReadLine(), out DateOnly hireDate);
								Console.Write("olke: ");
								string? country = Console.ReadLine()?.Trim();
								Console.Write("seher: ");
								string? city = Console.ReadLine()?.Trim();
								Employee employee = new()
								{
									FirstName = firstName,
									LastName = lastName,
									Title = title,
									HireDate = hireDate,
									Country = country,
									City = city
								};
								employeeService.Add(employee);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								List<Employee> employees = employeeService.GetAll();
								foreach (Employee employee in employees)
								{
									Console.WriteLine($"{employee.EmployeeId}) {employee.FirstName} {employee.LastName} {employee.Country} {employee.City}");
								}
								Console.Write("isci idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int employeeId);
								Employee employee1 = employeeService.Get(employeeId);
								Console.WriteLine($"kohne ad soyad: {employee1.FirstName} {employee1.LastName}");
								Console.Write("yeni ad: ");
								string? newFirstName = Console.ReadLine()?.Trim();
								Console.Write("yeni soyad: ");
								string? newLastName = Console.ReadLine()?.Trim();
								if (!string.IsNullOrEmpty(newFirstName) && !string.IsNullOrEmpty(newLastName))
								{
									employeeService.Update(employeeId, newFirstName, newLastName);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								List<Employee> employees = employeeService.GetAll();
								foreach (Employee employee in employees)
								{
									Console.WriteLine($"{employee.EmployeeId}) {employee.FirstName} {employee.LastName} {employee.Country} {employee.City}");
								}
								Console.Write("isci idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int employeeId);
								employeeService.Delete(employeeId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 4:
							try
							{
								List<Employee> employees = employeeService.GetAll();
								foreach (Employee employee in employees)
								{
									Console.WriteLine($"{employee.EmployeeId}) {employee.FirstName} {employee.LastName}, ise alinma tarixi:{employee.HireDate}, olke:{employee.Country}, seher:{employee.City}");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 0:
							loop = false;
							break;
						default:
							throw new OperationNotFoundException("emeliyyat tapilmadi");
					}
				}
				catch (OperationNotFoundException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		private static void OrderMenu()
		{
			OrderService orderService = new();
			EmployeeService employeeService = new();
			CustomerService customerService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(orderMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								employeeService.GetAll();
								customerService.GetAll();
								Console.Write("sifaris tarixi: ");
								DateOnly.TryParse(Console.ReadLine(), out DateOnly orderDate);
								Console.Write("catdirilma tarixi: ");
								DateOnly.TryParse(Console.ReadLine(), out DateOnly shippedDate);
								List<Customer> customers = customerService.GetAll();
								foreach (Customer customer in customers)
								{
									Console.WriteLine($"{customer.CustomerId}) {customer.ContactName} {customer.City} {customer.Country}");
								}
								Console.Write("musteri idsi: ");
								int.TryParse(Console.ReadLine(), out int customerId);
								customerService.Get(customerId);
								List<Employee> employees = employeeService.GetAll();
								foreach (Employee employee in employees)
								{
									Console.WriteLine($"{employee.EmployeeId}) {employee.FirstName} {employee.LastName} {employee.Country} {employee.City}");
								}
								Console.Write("isci idsi: ");
								int.TryParse(Console.ReadLine(), out int employeeId);
								employeeService.Get(employeeId);
								Order order = new()
								{
									OrderDate = orderDate,
									ShippedDate = shippedDate,
									CustomerId = customerId,
									EmployeeId = employeeId
								};
								orderService.Add(order);
							}
							catch (Exception ex)
							{
								if (ex is NoCustomersException || ex is NoEmployeesException)
								{
									Console.WriteLine("sistemde en azi bir musteri ve isci olmalidir");
								}
								else
								{
									Console.WriteLine(ex.Message);
								}
							}
							break;
						case 2:
							try
							{
								List<Order> orders = orderService.GetAll();
								foreach (Order order in orders)
								{
									Console.WriteLine($"{order.OrderId}) sifaris tarixi: {order.OrderDate}, catdirilma tarixi: {order.ShippedDate}, musteri idsi: {order.CustomerId}, isci idsi: {order.EmployeeId}");
								}
								Console.Write("sifaris idsi: ");
								int.TryParse(Console.ReadLine(), out int orderId);
								orderService.Delete(orderId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								List<Order> orders = orderService.GetAll();
								foreach (Order order in orders)
								{
									Console.WriteLine($"{order.OrderId}) sifaris tarixi: {order.OrderDate}, catdirilma tarixi: {order.ShippedDate}, musteri idsi: {order.CustomerId}, isci idsi: {order.EmployeeId}");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 0:
							loop = false;
							break;
						default:
							throw new OperationNotFoundException("emeliyyat tapilmadi");
					}
				}
				catch (OperationNotFoundException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
