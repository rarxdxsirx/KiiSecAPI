namespace KiiSecAPI.Dto
{
    public class VisitRequestDto
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int VisitorsGroupID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string VisitPurpose { get; set; }
        public int VisitStatusID { get; set; }
    }
}
