using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TrackerModels.Models;
using Moq;
using TrackerRepositories.Interfaces;

namespace Tracker.Business.Tests
{
    [TestFixture]
    [Category("ACR development phase module")]
    public class ACRStatusTests
    {
        private Mock<IACRRepository> _acrRepository;
        private Mock<IStatusRepository> _statusRepository;
        private IACRRepository _ACRRepository;
        private IList<ACR> _acr;
        private IList<StatusMaster> _status;



        [SetUp]
        public void Init()
        {

            _status = new List<StatusMaster>
            {
                new StatusMaster { StatusId=1,StatusName="ACR Created",IsActive=true},
                new StatusMaster { StatusId=2, StatusName ="ACR Submitted", IsActive=true},
                new StatusMaster { StatusId=3, StatusName ="ACR Approved", IsActive=true},
                new StatusMaster { StatusId=4, StatusName ="ACR Scheduled", IsActive=true},
                new StatusMaster { StatusId=5, StatusName ="ACR Assigned", IsActive=true},
                new StatusMaster { StatusId=6, StatusName ="ACR Cancelled", IsActive=true},
                new StatusMaster { StatusId=7, StatusName ="ACR In Progress", IsActive=true},
                new StatusMaster { StatusId=8, StatusName ="ACR Deployed Development", IsActive=true},
                new StatusMaster { StatusId=5, StatusName ="ACR Deployed OAT/Staging", IsActive=true},
                new StatusMaster { StatusId=5, StatusName ="ACR Deployed Production", IsActive=true},
                new StatusMaster { StatusId=9, StatusName ="ACR Completed", IsActive=true}

            };

            _acr = new List<ACR>
            {
                new ACR { ACRID=1,ACR_Name="Dofa_ACR_20",ApplicationId=0,ApprovedBy="None",AssigneeMapping=0,CreatedBy=1,CreatedDate=DateTime.Now,EndDate=DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)),isActive=true,RaisedBy=1,StatusId=2,Summary="This is ACR module test"}


            };

          _statusRepository  = new Mock<IStatusRepository>();
          _acrRepository = new Mock<IACRRepository>();

         

        }


        [Test]
        public void Status_Table_Returns_All_Active_Status()
        {

            _statusRepository.Setup(s => s.All).Returns(It.IsAny<IQueryable<StatusMaster>>());
           
            

        }

        [Test]
        public void ACR_Status_Column_Picks_Correct_Status_Value()
        {

           _acrRepository.Setup(a => a.GetACRStatus(It.IsAny<int>())).Returns("ACR Submitted");
           IACRRepository _mockACR = _acrRepository.Object;
          var result =  _mockACR.GetACRStatus(2);

          Assert.AreEqual("ACR Submitted", result);

          
           
        }

    }
}
