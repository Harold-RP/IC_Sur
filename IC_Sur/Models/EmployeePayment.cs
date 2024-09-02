namespace IC_Sur.Models
{
    public class EmployeePayment
    {
        public int EmployeePaymentId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public double Amount { get; set; }
        public DateTime DateTimePayment { get; set; }
        public string? Detail { get; set; }
        public double? Discount { get; set; }
    }
}
