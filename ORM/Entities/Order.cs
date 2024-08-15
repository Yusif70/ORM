namespace ORM.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly ShippedDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
