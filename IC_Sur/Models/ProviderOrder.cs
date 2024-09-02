namespace IC_Sur.Models
{
    public class ProviderOrder
    {
        public int ProviderOrderId { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public int MyProperty { get; set; }

    }
}
