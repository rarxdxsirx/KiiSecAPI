﻿namespace KiiSecAPI.Models
{
    // Not neccesary?
    public class Visit
    {
        public int ID { get; set; }
        public int VisitorsGroupID { get; set; }
        public int EmployeeID { get; set; }
        public int VisitRequestID { get; set; }
        public DateTime Date { get; set; }
        public string VisitPurpose { get; set; }
        public int VisitStatusID { get; set; }


        //public Visit(VisitRequest visitRequest, DateTime date)
        //{
        //    ID = visitRequest.ID;
        //    VisitGroup = visitRequest.VisitGroup;
        //    EmployeeID = visitRequest.EmployeeID;
        //    Date = date;
        //}
    }
}
