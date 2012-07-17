using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using TrackerRepositories.Interfaces;
using TrackerModels.Models;

namespace Tracker.Business.Tests
{
    [TestFixture]
    public class CalculateACREndDate
    {
        private DateTime StartDate;
        private DateTime EndDate;
        private int numberOfPersonWorkingOnTask;
        private string currentACRStatus;
        private double estimatedEfforts;
        private const int EffortConversionFactor = 9;
        private Mock<IACRRepository> _acrRepository;
        private Mock<IStatusRepository> _statusRepository;
        private IList<ACR> _acr;
        private IList<StatusMaster> _status;

        [SetUp]
        public void Init()
        {

            _status = FakeDatabase.StatusList();

            _acr = FakeDatabase.AcrList();

            _statusRepository = new Mock<IStatusRepository>();
            _acrRepository = new Mock<IACRRepository>();
        }


        [Test]
        public void Calculate_ACR_End_Date_Based_On_Scheduled_Status_And_StartDate()
        {
            var acrStatus= FakeDatabase.StatusList().Single(s => s.StatusName == "ACR Scheduled").StatusName.ToString();
            StartDate = DateTime.Now;
            estimatedEfforts = FakeDatabase.AcrList().Single(s => s.ACRID == 1).EstimatedEfforts;
            numberOfPersonWorkingOnTask = FakeDatabase.AcrList().Single(a => a.ACRIID==1).AssigneeMapping
             var endDate = GetEndDate(StartDate,estimatedEfforts, acrStatus);

            

        }

        private DateTime GetEndDate(DateTime StartDate, double estimatedEfforts, string acrStatus)
        {
            if (acrStatus == "ACR Scheduled")
            {
                double totalHours = estimatedEfforts * EffortConversionFactor;
                DateTime endDate = StartDate.ToUniversalTime().AddHours(totalHours).ToA;
                return DateTime.Now;
            }

            else
            {
                throw new InvalidOperationException("ACR Not Scheduled");
            }
            
        }

    }
}
