using KiiSecAPI.Data;
using KiiSecAPI.Models;
using System.Diagnostics.Metrics;

namespace KiiSecAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            //if (!dataContext.Organizations.Any())
            //{
            //    var Organizations = new List<Organization>()
            //    {
            //        new Organization()
            //        {
            //            Name = "Организация 1",
            //            Login = "org1",
            //            Password = "password1",
            //            Employees = new List<Employee>()
            //            {
            //                //new Employee() { OrganizationId = 1, FirstName = "Jason", LastName = "Myers", Password = "jason1", Login = "O1Emp1",  Department = "Security", Email = "chxsscom@gmail.com",
            //                //    Permissions = Permissions.UpdateVisitStatus.ToString(), PhoneNumber="89136340195", BirthDate = new DateTime(1998,5,6) },
            //                //new Employee() { OrganizationId = 1, FirstName = "Robert", LastName = "Mills", Password = "robert1", Login = "O1Emp2",  Department = "Common", Email = "chxsscom@gmail.com",
            //                //    Permissions = Permissions.SetVisitDate.ToString(), PhoneNumber="89136340195", BirthDate = new DateTime(2000,1,2)}
            //            },
            //            VisitRequests = new List<VisitRequest>()
            //            {
            //                //new VisitRequest() {EmployeeID = 1, VisitorsGroupID = 1, DateStart = new DateTime(2023,10,1), DateEnd = new DateTime(2023,10,14),
            //                //    VisitPurpose = "Job", VisitStatus = VisitStatus.Status.Pending},
            //                //new VisitRequest() {EmployeeID = 2, VisitorsGroupID = 2, DateStart = new DateTime(2023,9,16), DateEnd = new DateTime(2023,10,25),
            //                //    VisitPurpose = "Business", VisitStatus = VisitStatus.Pending},
            //            },
            //            VisitorsGroups = new  List<VisitorsGroup>()
            //            {
            //                new VisitorsGroup()
            //                {
            //                    Visitors = new List<Visitor>()
            //                    {
            //                        new Visitor() { FirstName = "Alex", LastName = "Morris", Login = "alex1", Password = "passalex" , PassportData = "4779 443894",
            //                            PhoneNumber="89136340195", BirthDate = new DateTime(2000,1,2),  Email = "chxsscom@gmail.com"},
            //                        new Visitor() {  FirstName = "Michael", LastName = "Morales", Login = "michael1", Password = "passmichael", PassportData = "4133 936298",
            //                            PhoneNumber="89136340195", BirthDate = new DateTime(2000,1,2),  Email = "chxsscom@gmail.com"},
            //                    }
            //                },
            //                new VisitorsGroup()
            //                {
            //                    Visitors = new List<Visitor>()
            //                    {
            //                        new Visitor() { FirstName = "Jack", LastName = "Moss", Login = "jack1", Password = "passjack", PassportData = "4181 839349",
            //                            PhoneNumber="89136340195", BirthDate = new DateTime(2000,1,2),  Email = "chxsscom@gmail.com"},
            //                        new Visitor() { FirstName = "Ron", LastName = "Mathis", Login = "ron1", Password = "passron", PassportData = "4966 740668",
            //                            PhoneNumber="89136340195", BirthDate = new DateTime(2000,1,2),  Email = "chxsscom@gmail.com"},
            //                    }
            //                }
            //            },
            //            Visits = new List<Visit>()
            //            {
            //                new Visit() { VisitorsGroupID = 1, EmployeeID = 1, VisitRequestID = 1, Date = new DateTime(2023, 10, 10), VisitPurpose = "Job"},
            //                new Visit() { VisitorsGroupID = 2, EmployeeID = 2, VisitRequestID = 2, Date = new DateTime(2023, 9, 20), VisitPurpose = "Business"}
            //            }
            //        }

            //    };
            //    dataContext.Organizations.AddRange(Organizations);
            //    dataContext.SaveChanges();
            //}
        }
    }
}
