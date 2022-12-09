using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Contracts;
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
    }
}
