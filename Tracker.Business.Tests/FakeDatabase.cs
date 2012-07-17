using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;

namespace Tracker.Business.Tests
{
    public static class FakeDatabase
    {
        //public static IList<StatusMaster> statusMaster;
        //public static IList<ACR> acr;

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

            //return statusMaster.ToList<StatusMaster>();

        }

        public static List<ACR> AcrList()
        {


          return new List<ACR>
            {
                new ACR { ACRID=1,ACR_Name="Dofa_ACR_20",ApplicationId=0,ApprovedBy="None",AssigneeMapping=0,CreatedBy=1,CreatedDate=DateTime.Now,EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)),isActive=true,RaisedBy=1,StatusId=2,Summary="This is ACR module test",EstimatedEfforts=10.5}


            };

            


        }
    }
}
