namespace IC_Sur.Models
{
    public class Assistance
    {
        public int AssistanceId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime ArrivalDatetime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public string? AssistanceMark { get; set; }

    }
}
