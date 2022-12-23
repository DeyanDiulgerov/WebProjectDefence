using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Contracts;
using WebProject.Data.Models;
using WebProject.Models.AdminViewModel;
using WebProject.Services;

namespace WebProject.Tests.UnitTests
{
    [TestFixture]
    public class AdminServiceTests : UnitTestsBase
    {
        private IAdminService adminService;

        [OneTimeSetUp]
        public void SetUp()
            => this.adminService = new AdminService(context);

        // Implement adminService - Approve, AddPotentialAdmin, potentialAdminsList methods!


        [Test]
        public void IsAdmin_ShouldReturnCorrectAdminId()
        {
            var adminId = this.Administrator.UserId;

            bool result = adminService.IsAdmin(adminId);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void AdminWithPhoneNumberExists_ShouldReturnTrueWithValidData()
        {
            // Arrange

            // Act: Invoke the service method with valid agent phone num
            var result = adminService.UserWithPhoneNumberExists(this.Administrator.PhoneNumber);

            // Assert the method result is true
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateAdmin_ShouldWorkCorrectly()
        {
            // Arrange: get all admin's current count
            var adminsCountBefore = context.Administrators.Count();

            // Act: Invoke the service method with valid data
            adminService.Create(this.Administrator.UserId, this.Administrator.PhoneNumber);

            // Assert the admins count has increased by 1
            var adminsCountAfter = context.Administrators.Count();
            Assert.That(adminsCountAfter, Is.EqualTo(adminsCountBefore + 1));

            // Assert a new admin was created in the Db with correct data
            var newAdminId = adminService.GetAdminId(this.Administrator.UserId);
            var newAdminInDb = context.Administrators.Find(newAdminId);
            Assert.IsNotNull(newAdminInDb);
            Assert.That(newAdminInDb.UserId, Is.EqualTo(this.Administrator.UserId));
            Assert.That(newAdminInDb.PhoneNumber, Is.EqualTo(this.Administrator.PhoneNumber));
        }

        [Test]
        public void AdminIdGet_ShouldReturnCorrectAdminId()
        {
            var newAdminUserId = this.Administrator.UserId;
            var newIntAdminUserId = this.Administrator.Id;

            var result = adminService.GetAdminId(newAdminUserId);

            Assert.IsNotNull(result);
            
            var adminInDb = context.Administrators.Find(newIntAdminUserId);
            Assert.That(adminInDb.Id, Is.EqualTo(result));
        }

        [Test]
        public void potentialAdminsList_ShouldReturnListOfPotentialAdmins()
        {
            var potentialAdmins = adminService.potentialAdminsList();
            Assert.IsNotNull(potentialAdmins);
        }

        [Test]
        public void AddPotentialAdmin_ShouldAddPotentialAdminToContextPotentialAdmins()
        {

            var newPotentialAdmin = new PotentialAdminViewModel()
            {
                PhoneNumber = "TestPhoneNumber",
                UserId = "TestTestTestPotentialAdminUserId"
            };

            var potentialAdminsBefore = context.PotentialAdmins.Count();

            adminService.AddPotentialAdmin(this.PotentialAdmin.UserId, newPotentialAdmin);

            var potentialAdminsAfter = context.PotentialAdmins.Count();

            Assert.That(potentialAdminsAfter, Is.EqualTo(potentialAdminsBefore + 1));

            var newAdminInDb = context.PotentialAdmins.Find(2);

            Assert.That(newAdminInDb.PhoneNumber, Is.EqualTo(newPotentialAdmin.PhoneNumber));
        }


        [Test]
        public void Approve_ShouldApprovePotentialAdminAndMakeHimRealAdmin()
        {
            var potentialAdminsBefore = context.PotentialAdmins.Count();
            var administratorsBefore = context.Administrators.Count();

            adminService.Approve(this.PotentialAdmin.Id);

            var potentialAdminsAfter = context.PotentialAdmins.Count();
            var administratorsAfter = context.Administrators.Count();

            Assert.That(potentialAdminsAfter, Is.EqualTo(potentialAdminsBefore - 1));
            Assert.That(administratorsAfter, Is.EqualTo(administratorsBefore + 1));

            var newAdminInDb = context.Administrators.Find(this.PotentialAdmin.Id);
            Assert.IsNotNull(newAdminInDb);
        }

        [Test]
        public void AllUsers_ShouldReturnAllUsersCorrectly()
        {
            var result = adminService.All();
            Assert.IsNotNull(result);
        }
    }
}
