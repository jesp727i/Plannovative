using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DomainLayer;

namespace Test
{
    [TestClass]
    public class JobUnitTest
    {
        JobRepository jobRepo;
        JobFactory jobFac;

        [TestInitialize]
        public void initialize()
        {
            jobRepo = new JobRepository();
            jobFac = new JobFactory();
        }

        [TestMethod]
        public void CanGetListFromRepo()
        {
            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
            Job newJob = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);

            jobRepo.SaveJob(newJob);

            var jobList = jobRepo.GetList();

            Assert.AreEqual(newJob.Name, jobList[0].Name);
        }

        [TestMethod]
        public void CanSaveOneJobToRepo()
        {
            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
            Job newJob = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
            jobRepo.SaveJob(newJob);

            int repoListCount = jobRepo.GetList().Count;

            Assert.AreEqual(1, repoListCount);
        }
        [TestMethod]
        public void CanSaveTwoJobToRepo()
        {
            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
            Job newJob1 = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
            Job newJob2 = new Job("Banner", newCustomer, "Lav et banner", Convert.ToDateTime("04/11/2017"), false, 200.00);

            jobRepo.SaveJob(newJob1);
            jobRepo.SaveJob(newJob2);
            int repoListCount = jobRepo.GetList().Count;

            Assert.AreEqual(2, repoListCount);
        }
        [TestMethod]
        public void CanSaveOneJobFromFactory()
        {
            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");

            jobFac.CreateJob("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
            jobFac.CreateJob("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
            int repoListCount = jobRepo.GetList().Count;
            Assert.AreEqual(2, repoListCount);
        }
    }
}
