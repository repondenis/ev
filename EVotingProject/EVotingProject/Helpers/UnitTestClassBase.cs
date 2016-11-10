﻿using System;
using System.Linq;
using NUnit.Framework;
using HP.LFT.Report;
using HP.LFT.UnitTesting;
using NUnit.Framework.Interfaces;
using HP.LFT.SDK.Web;


namespace EVotingProject
{


    [TestFixture]
    public abstract class UnitTestClassBase : UnitTestBase
    {

        public  IBrowser browser;
        public string urlDemo = "https://demo-evoting.test.gosuslugi.ru/";//idp/sso#/
        public string urlDemoAdmin = "https://demo-evoting.test.gosuslugi.ru/idp/sso#/?admin";//ивотинг для администратора
        public string urlDev = "https://portal-dev-evoting.test.gosuslugi.ru/";
        public string urlDevAdmin = "https://portal-dev-evoting.test.gosuslugi.ru/idp/sso#/local?admin";//ивотинг для администратора

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