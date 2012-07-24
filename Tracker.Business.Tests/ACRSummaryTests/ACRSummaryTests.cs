using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TrackerModels.Models;
using Moq;
using TrackerRepositories.Interfaces;
using TrackerRepositories.Repositories;

namespace Tracker.Business.Tests.ACRSummaryTests
{
    [TestFixture]
    public class ACRSummaryTests
    {
   
        private Mock<IACRRepository> _acrSumRepository = new Mock<IACRRepository>();
        private Mock<IACRRepository> _acrStatusRepository = new Mock<IACRRepository>();
        private Mock<IACRRepository> _acrAssignedToRepository = new Mock<IACRRepository>();
        private IList<StatusMaster> _acrStatus;
        private IList<ACR> _acrDetails;
        private IList<Users> _UsersAssignedToACR;
        private IList<AssigneeMapping> _assignees;
        private IACRRepository _ACRRepository;
        private IACRRepository _ACRStatusRepository;
        private IACRRepository _ACRAssignedToRepository;

   
        [SetUp]
        public void ACRSumamrySetup()
        {
            _acrDetails = FakeDatabase.AcrList();
            _acrStatus = FakeDatabase.StatusList();
            _UsersAssignedToACR = FakeDatabase.UserList();
            _assignees = FakeDatabase.GetAssignees();
            
            _acrSumRepository.Setup(a => a.GetACRSummary(It.IsAny<int>())).Returns((int i) => _acrDetails.Where(x => x.ACRID == i).Single().Summary.ToString());
            _acrStatusRepository.Setup(a => a.GetACRStatus(It.IsAny<int>())).Returns((int i) => _acrStatus.Where(x => x.StatusId == _acrDetails.FirstOrDefault().StatusId).Single().StatusName.ToString());
            _acrAssignedToRepository.Setup(a => a.ACRAssignedTo(It.IsAny<int>())).Returns(() => _assignees.Where(a => a.UserId==_UsersAssignedToACR.FirstOrDefault().UserID).Select(s => s.User.FirstName +" "+ s.User.LastName).ToList<string>());
            this._ACRRepository = _acrSumRepository.Object;
            this._ACRStatusRepository = _acrStatusRepository.Object;
            this._ACRAssignedToRepository = _acrAssignedToRepository.Object;

        }

        [Test]
        public void check_Summary_contains_value()
        {
            string ACRSummary = this._ACRRepository.GetACRSummary(1);
            Assert.IsNotNull(ACRSummary);
            Assert.AreEqual("This is ACR module test", ACRSummary);
            
        }

        [Test]
        public void check_Correct_Status_Value()
        {
            string ACRStatus = this._ACRStatusRepository.GetACRStatus(1);
            Assert.AreEqual("ACR Scheduled", ACRStatus);

        }

        [Test]
        public void Check_ACR_Assigned_To_CorrectUser()
        {
            List<string> ACRAssignedTo = this._ACRAssignedToRepository.ACRAssignedTo(2);
                Assert.AreEqual(1,ACRAssignedTo.Count);
                Assert.AreEqual("Monika Mathur", ACRAssignedTo.First().ToString());
        }



    }
}
