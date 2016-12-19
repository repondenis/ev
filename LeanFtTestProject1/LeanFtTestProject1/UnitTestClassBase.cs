using System;
using System.Linq;
using NUnit.Framework;
using HP.LFT.Report;
using HP.LFT.UnitTesting;
using NUnit.Framework.Interfaces;

/// <summary>
/// Runs before all classes and tests in the current project.
/// <remarks>This class must remain outside any namespace in order to provide setup and tear down for the entire assembly.
/// To get more information follow this link: https://github.com/nunit/docs/wiki/SetUpFixture-Attribute
/// </remarks>
/// </summary>
[SetUpFixture]
public class SetupFixture : UnitTestSuiteBase
{
    [OneTimeSetUp]
    public void AssemblySetUp()
    {
        TestSuiteSetup(TestContext.CurrentContext.WorkDirectory);
    }

    [OneTimeTearDown]
    public void AssemblyTearDown()
    {
        TestSuiteTearDown();

        Reporter.GenerateReport();
    }
}

namespace LeanFtTestProject1
{
    [TestFixture]
    public abstract class UnitTestClassBase : UnitTestBase
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            TestSuiteSetup();
        }

        [SetUp]
        public void BasicSetUp()
        {
            TestSetUp();
        }

        [TearDown]
        public void BasicTearDown()
        {
            TestTearDown();
        }

        protected override string GetClassName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }

        protected override string GetTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }

        protected override Status GetFrameworkTestResult()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Failed:
                    return Status.Failed;
                case TestStatus.Inconclusive:
                case TestStatus.Skipped:
                    return Status.Warning;
                case TestStatus.Passed:
                    return Status.Passed;
                default:
                    return Status.Passed;
            }
        }
    }
}
