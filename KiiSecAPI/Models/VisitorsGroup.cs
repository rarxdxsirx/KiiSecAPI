﻿namespace KiiSecAPI.Models
{
    public class VisitorsGroup
    {
        public int ID { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
    }
}