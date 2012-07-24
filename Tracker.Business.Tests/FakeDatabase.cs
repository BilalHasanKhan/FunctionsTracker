using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;

namespace Tracker.Business.Tests
{
    public static class FakeDatabase
    {
      
        public static List<StatusMaster> StatusList()
        {

            return new List<StatusMaster>
            {
                new StatusMaster { StatusId=1,StatusName="ACR Created",IsActive=true},
                new StatusMaster { StatusId=2, StatusName ="ACR Submitted", IsActive=true},
                new StatusMaster { StatusId=3, StatusName ="ACR Approved", IsActive=true},
                new StatusMaster { StatusId=4, StatusName ="ACR Scheduled", IsActive=true},
                new StatusMaster { StatusId=5, StatusName ="ACR Assigned", IsActive=true},
                new StatusMaster { StatusId=6, StatusName ="ACR Cancelled", IsActive=true},
                new StatusMaster { StatusId=7, StatusName ="ACR In Progress", IsActive=true},
                new StatusMaster { StatusId=8, StatusName ="ACR Deployed Development", IsActive=true},
                new StatusMaster { StatusId=9, StatusName ="ACR Deployed OAT/Staging", IsActive=true},
                new StatusMaster { StatusId=10, StatusName ="ACR Deployed Production", IsActive=false},
                new StatusMaster { StatusId=11, StatusName ="ACR Completed", IsActive=true}

            };

           

        }

        public static List<ACR> AcrList()
        {


          return new List<ACR>
            {
                new ACR { ACRID=1,ACR_Name="Dofa_ACR_20",ApplicationId=0,ApprovedBy="None",CreatedBy=1,CreatedDate=DateTime.Now,EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)),isActive=true,RaisedBy=1,StatusId=4,Summary="This is ACR module test",EstimatedEfforts=10.5}


            };

            


        }

        public static List<AssigneeMapping> GetAssignees()
        {

            return new List<AssigneeMapping>
            {
                new AssigneeMapping {AssigneeMappingId=1,ACRId=1,UserId=1,User=UserList().FirstOrDefault()},
                new AssigneeMapping {AssigneeMappingId=2,ACRId=2,UserId=2},
                new AssigneeMapping {AssigneeMappingId=3,ACRId=2,UserId=3},
                new AssigneeMapping {AssigneeMappingId=4,ACRId=2,UserId=4}

            };

        }
        
         // Added By Sadaf
        public static List<ACR> ACRList()
        {
            return new List<ACR> 
            {
                 new ACR {ACRID=1, ACR_Name="ACR1", Summary="This is to test ACR1", ApplicationId=11, StatusId=1, ApprovedBy="Team1",  CreatedBy=1, CreatedDate=DateTime.Now, EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)), isActive=true, RaisedBy=1,EstimatedEfforts=10.1},
                new ACR {ACRID=2, ACR_Name="ACR2", Summary="This is to test ACR2", ApplicationId=12, StatusId=2, ApprovedBy="Team2",  CreatedBy=2, CreatedDate=DateTime.Now, EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)), isActive=true, RaisedBy=2, EstimatedEfforts=10.2},
                new ACR {ACRID=3, ACR_Name="ACR3", Summary="This is to test ACR3", ApplicationId=11, StatusId=2, ApprovedBy="Team3",  CreatedBy=2, CreatedDate=DateTime.Now, EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)), isActive=true, RaisedBy=3, EstimatedEfforts=10.3},
                new ACR {ACRID=4, ACR_Name="ACR4", Summary="This is to test ACR4", ApplicationId=14, StatusId=2, ApprovedBy="Team4",  CreatedBy=4, CreatedDate=DateTime.Now, EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)), isActive=true, RaisedBy=4, EstimatedEfforts=10.4}
            };
        }
        
        //Added By Monika
        public static List<Users> UserList()
        {
            return new List<Users>
            {
           
                new Users { UserID = 1, FirstName="Monika", LastName="Mathur", BPEmailID="monika.mathur@bp.com",  Contact1=0000, CreatedDate=DateTime.Now, NTID="",  EmpID=0, SoftwareMappingID=0, AssetID=0, Contact2=0000000000000, CreatedBy=" ", IsActive=true, ModifiedBy=" ", ModifiedDate=DateTime.Now }
            };
        }

    }
}
