using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
<<<<<<< HEAD
using TrackerRepositories.Interfaces;
using Moq;
using TrackerModels.Models;
=======
using TrackerModels.Models;
using Moq;
using TrackerRepositories.Interfaces;
>>>>>>> origin/master

namespace Tracker.Business.Tests
{
    class ACRLandingPageTests
    {
        [TestFixture]
    [Category("Unit Test Cases for ACR Landing Page")]
    public class ACRandingPageUnitTest1
    {
        private IACRRepository _acrRepository;
        private Mock<IACRRepository> _mockACRRepository;
        private IList<ACR> _testACR;

        [SetUp]
        public void InitSetUp()
        {
            _testACR = FakeDatabase.ACRList();            

            _mockACRRepository = new Mock<IACRRepository>();

            // Try Finding All ACRs            
            _mockACRRepository.Setup(a => a.FindAll()).Returns(_testACR);


            // Try finding ACRs by ACR Name
            _mockACRRepository.Setup(a => a.FindByACRName(It.IsAny<string>())).Returns((string s) => _testACR.Where(x => x.ACR_Name == s).Single());


            // Try finding ACRs by AppId
            _mockACRRepository.Setup(a => a.FindByAppId(It.IsAny<int>())).Returns((int i) => _testACR.Where(x => x.ApplicationId == i).ToList());

            // Try finding ACRs by StatusId
            _mockACRRepository.Setup(a => a.FindByStatusId(It.IsAny<int>())).Returns((int i) => _testACR.Where(x => x.StatusId == i).ToList());

            // Try Saving the Changes 
            _mockACRRepository.Setup(a => a.Save()).Verifiable("Save Not Successful");

            // Insert or Update
            _mockACRRepository.Setup(a => a.InsertOrUpdate(It.IsAny<ACR>())).Callback(
                (ACR acrTarget) =>
                {
                    if (acrTarget.ACRID.Equals(default(int))) // for INSERT
                    {
                        acrTarget.ACRID = _testACR.Count() + 1;
                        _testACR.Add(acrTarget);
                    }

                    else // for UPDATE
                    {
                        var original = _testACR.Where(o => o.ACRID == acrTarget.ACRID).Single();
                        original.ACR_Name = acrTarget.ACR_Name;
                        original.ApplicationId = acrTarget.ApplicationId;
                        original.Summary = acrTarget.Summary;
                        original.StatusId = acrTarget.StatusId;
                    }

                });

            this._acrRepository = _mockACRRepository.Object;
        }

        [Test]
        public void CanReturnAllACRs()
        {
            List<ACR> testACR = this._acrRepository.FindAll().ToList();
            Assert.AreEqual(4, testACR.Count);
        }

        [Test]
        public void CanReturnACRsByACRName()
        {

            ACR testACR = this._acrRepository.FindByACRName("ACR1");
            //Assert.IsNotNull(testACR);
            Assert.AreEqual(1, testACR.ACRID);
        }

        [Test]
        public void CanFindACRsByAppId()
        {
            List<ACR> testACR = this._acrRepository.FindByAppId(11);
            Assert.AreEqual(2, testACR.Count);
        }

        [Test]
        public void CanReturnACRsByStatusId()
        {
            List<ACR> testACR = this._acrRepository.FindByStatusId(2);
            Assert.AreEqual(3, testACR.Count);
        }

        [Test]
        public void CanSaveAnyChangesAfterInsert()
        {
            // Try to save after inserting a new ACR
            ACR newACR = new ACR { ACR_Name = "ACR5", Summary = "This is to test ACR5", ApplicationId = 15, StatusId = 2, ApprovedBy = "Team4",  CreatedBy = 4, CreatedDate = DateTime.Now, EndDate = DateTime.UtcNow.Add(TimeSpan.FromDays(30.00)), isActive = true, RaisedBy = 4 };
            int _intACRCount = this._acrRepository.FindAll().Count;
            Assert.AreEqual(4, _intACRCount); // Verify pre-insert count value
            this._acrRepository.InsertOrUpdate(newACR);



            // Recounting
            _intACRCount = this._acrRepository.FindAll().Count; // Verify post-insert count value
            Assert.AreEqual(5, _intACRCount);

            // Verify foe SAVE after INSERT
            ACR testACR = this._acrRepository.FindByACRName("ACR5");
            Assert.AreEqual(5, testACR.ACRID);

        }

        [Test]
        public void CanSaveAnyChangesAfterUpdates()
        {
            // Try Updating an existing ACR
            ACR testACR = this._acrRepository.FindByACRName("ACR3");
            testACR.Summary = "This is to test for Saving Changes after any Updates for ACR3";

            // Update the Changes
            this._acrRepository.InsertOrUpdate(testACR);
            var updates = this._acrRepository.FindByACRName("ACR3").Summary;
            Assert.AreEqual("This is to test for Saving Changes after any Updates for ACR3", updates);
        }



    }
    }
}
