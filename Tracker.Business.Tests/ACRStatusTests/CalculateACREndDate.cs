using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using TrackerRepositories.Interfaces;
using TrackerModels.Models;
using FluentDateTime;
using TrackerBusiness.ACR;

namespace Tracker.Business.Tests
{
    [TestFixture]
    public class CalculateACREndDate
    {
        private DateTime StartDate;
        private int numberOfPersonWorkingOnTask;
        private double estimatedEfforts;
        private const int EffortConversionFactor = 9;
        private Mock<IACRRepository> _acrRepository;
        private Mock<IStatusRepository> _statusRepository;
        private IList<ACR> _acr;
        private IList<StatusMaster> _status;
        private IList<AssigneeMapping> _assigneeMapping;
        private IACRRepository _ACRRepository;
        private IStatusRepository _StatusRepository;
        private ACRStatus _acrStatus;

        [SetUp]
        public void Init()
        {

            _status = FakeDatabase.StatusList();

            _acr = FakeDatabase.AcrList();

            _assigneeMapping = FakeDatabase.GetAssignees();

            _statusRepository = new Mock<IStatusRepository>();
            _acrRepository = new Mock<IACRRepository>();

            _acrStatus = new ACRStatus();
            _acrRepository.Setup(a => a.GetNumberOfAssignees(It.IsAny<int>())).Returns((int i) => _assigneeMapping.Where(m => m.ACRId==i).Count());
            _acrRepository.Setup(a => a.GetACRStatus(It.IsAny<int>())).Returns(() => _status.Where(x => x.StatusId == _acr.FirstOrDefault().StatusId).Single().StatusName.ToString());
            this._ACRRepository = _acrRepository.Object;
            this._StatusRepository = _statusRepository.Object;
       }


        [Test]
        public void Calculate_ACR_End_Date_Based_On_Scheduled_Status_And_StartDate()
        {
            var acrStatus = this._ACRRepository.GetACRStatus(1);
            StartDate = DateTime.Now;
            estimatedEfforts = FakeDatabase.AcrList().Single(s => s.ACRID == 1).EstimatedEfforts;
            numberOfPersonWorkingOnTask = this._ACRRepository.GetNumberOfAssignees(1);
                                          
             var endDate = _acrStatus.GetEndDate(StartDate,estimatedEfforts, acrStatus,numberOfPersonWorkingOnTask);

             Assert.That(endDate.Day.Equals(23));

            

        }

       

      

    }
}
