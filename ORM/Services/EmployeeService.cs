using ORM.CodeFirst;
using ORM.Entities;
using ORM.Exceptions.EmployeeExceptions;

namespace ORM.Services
{
	public class EmployeeService
	{
		private readonly TestDBContext context = new();
		public void Add(Employee employee)
		{
			context.Add(employee);
			context.SaveChanges();
		}
		public void Update(int id, string newFirstName, string newLastName)
		{
			Employee employee = Get(id);
			employee.FirstName = newFirstName;
			employee.LastName = newLastName;
			context.Update(employee);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Employee employee = Get(id);
			context.Remove(employee);
			context.SaveChanges();
		}
		public List<Employee> GetAll()
		{
			List<Employee> employees = [.. context.Employees];
			if (employees.Count > 0)
			{
				return employees;
			}
			else
			{
				throw new NoEmployeesException("sistemde isci yoxdur");
			}
		}
		public Employee Get(int id)
		{
			Employee? employee = GetAll().Find(employee => employee.EmployeeId == id);
			if (employee != null)
			{
				return employee;
			}
			else
			{
				throw new EmployeeNotFoundException("isci tapilmadi");
			}
		}
	}
}
