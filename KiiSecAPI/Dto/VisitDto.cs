namespace KiiSecAPI.Dto
{
    public class VisitDto
    {
        public int ID { get; set; }
        public int VisitorsGroupID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public string VisitPurpose { get; set; }
        public int VisitStatusID { get; set; }
    }
}
