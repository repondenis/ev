using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using EVotingProject.Pages;

namespace EVotingProject.Tests.other
{
    [TestFixture]
    public class SearhOrgTest : UnitTestClassBase
    {
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test]
        [Ignore("")]
        public void Test(string orgNameTrue, string orgNameFalse)
        {

            //step-1
            PortalPage.gotoMenuOrganizations();
            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgNameTrue);

            //проверяем есть ли текущий org в табл пользователей
            OrganizationPage.getOrganizationTable(orgNameTrue);

            //step-2
            PortalPage.gotoMenuOrganizations();
            Assert.True(OrganizationPage.isTruePage());
            OrganizationPage.setOrganizationSearhInput(orgNameFalse);

            //проверяем НЕТ ли текущий org в табл пользователей
            OrganizationPage.getOrganizationTable(orgNameFalse);

        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
