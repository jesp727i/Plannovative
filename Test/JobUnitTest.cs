using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DomainLayer;
using System.Collections.Generic;


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


//        [TestMethod]
//        public void CanGetListFromRepo()
//        {
//            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
//            Job newJob = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);


//            jobRepo.SaveJob(newJob);

//            var jobList = jobRepo.GetList();

//            Assert.AreEqual(newJob.Name, jobList[0].Name);
//        }


//        [TestMethod]
//        public void CanSaveOneJobToRepo()
//        {
//            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
//            Job newJob = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
//            jobRepo.SaveJob(newJob);



//            int repoListCount = jobRepo.GetList().Count;


//            Assert.AreEqual(1, repoListCount);
//        }
//        [TestMethod]
//        public void CanSaveTwoJobToRepo()
//        {
//            Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");
//            Job newJob1 = new Job("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
//            Job newJob2 = new Job("Banner", newCustomer, "Lav et banner", Convert.ToDateTime("04/11/2017"), false, 200.00);


//            jobRepo.SaveJob(newJob1);
//            jobRepo.SaveJob(newJob2);
//            int repoListCount = jobRepo.GetList().Count;


//            Assert.AreEqual(2, repoListCount);
//        }
//        //[TestMethod]
//        //public void CanSaveOneJobFromFactory()
//        //{
//        //    Customer newCustomer = new Customer("Jimmi", "jimmi@hotmail.dk", "28734552", "denvej 10", "5000", "Odense", "88889999");

//        //    jobFac.CreateJob("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
//        //    jobFac.CreateJob("logo", newCustomer, "Lav et logo", Convert.ToDateTime("04/10/2017"), true, 200.00);
//        //    int repoListCount = jobRepo.GetList().Count;
//        //    Assert.AreEqual(2, repoListCount);
//        //}


//    }
//}

        [TestMethod]
        public void TimespanTest()
        {
            TimeSpan TS1 = new TimeSpan(0, 2, 30);
            TimeSpan TS2 = new TimeSpan(3, 3, 50);
            TimeSpan TS3 = TS2 - TS1;
            TimeSpan Result = new TimeSpan(3,1,20);
            Assert.AreEqual(Result.Hours,3);
            Assert.AreEqual(Result,TS3);
           
        }

        [TestMethod]
        public void CalculateTimeUsedTest()
        {
            List<WorkTime> TimeList = new List<WorkTime>();
            WorkTime WT01 = new WorkTime(new TimeSpan( 10,30,00), new TimeSpan (12,30,00), new DateTime());
            WorkTime WT02 = new WorkTime(new TimeSpan(11, 30, 00), new TimeSpan(17, 30, 00), new DateTime());
            WorkTime WT03 = new WorkTime(new TimeSpan(07, 00, 00), new TimeSpan(12, 30, 00), new DateTime());

            TimeList.Add(WT01);
            TimeList.Add(WT02);
            TimeList.Add(WT03);

            JobLogic JL = new JobLogic();
            Assert.AreEqual(JL.CalculateTimeUsed(TimeList), 13.5);
        
        }
    }
}