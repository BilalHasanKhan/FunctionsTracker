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
        private IStatusRepository _StatusRepository;
        private IList<ACR> _acr;
        private IList<StatusMaster> _status;
        


        [SetUp]
        public void ACRTestSetUp()
        {

                    _status = FakeDatabase.StatusList();

                    _acr = FakeDatabase.AcrList();

                    _statusRepository  = new Mock<IStatusRepository>();
                    _acrRepository = new Mock<IACRRepository>();

                    _acrRepository.Setup( a => a.GetACRStatus(It.IsAny<int>())).Returns((int i) => _status.Where(x => x.StatusId==i).Single().StatusName.ToString());
                   

                    _statusRepository.Setup(s => s.All).Returns(_status.Where(i => i.IsActive==true).AsQueryable<StatusMaster>());

                    this._ACRRepository = _acrRepository.Object;

                    this._StatusRepository = _statusRepository.Object;
         

        }


        [Test]
        public void Status_Table_Returns_All_Active_Status()
        {


           List<StatusMaster> allStatus = this._StatusRepository.All.ToList<StatusMaster>();

           Assert.AreEqual(10, allStatus.Count);

            

        }

        [Test]
        public void ACR_Status_Column_Picks_Correct_Status_Value()
        {

            string acrStatus = this._ACRRepository.GetACRStatus(1);
            Assert.AreEqual("ACR Created", acrStatus);

        

          
           
        }

        [Test]
        public void Correct_ACR_Is_Returned_When_Searched_By_Name()
        {


        }

    }
}
