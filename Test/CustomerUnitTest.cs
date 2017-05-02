using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DomainLayer;
using DataAccessLayer;

namespace Test
{
    [TestClass]
    public class CustomerUnitTest
    {
        CustomerFactory CustFac;
        CustomerRepository CustRepo;
        Customer cust1;
        Customer cust2;

        [TestInitialize]
        public void TestInitialize()
        {
            CustRepo = new CustomerRepository();
            CustFac = new CustomerFactory();
            cust1 = new Customer("Jens", "jens.dideriksen@gmail.dk", "24611962", "Bispevænget 5", "5000", "Odense", "80773");
            cust2 = new Customer("Jimmi", "JimmiSnutten@flotfyr.dk", "22334455", "HerPåSkolen", "5000", "Odense", "223344");
        }


        [TestMethod]
        public void CustomerAddedToRepo() //A customer gets saved in the repository
        {
            int repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(0, repoListCount);

            CustRepo.SaveCustomer(cust1);
            repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(1, repoListCount);

        }

        [TestMethod]

        public void TwoCustomersAddedToRepo() //Two customers gets saved in repository
        {
            int repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(0, repoListCount);

            CustRepo.SaveCustomer(cust1);
            CustRepo.SaveCustomer(cust2);
            repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(2, repoListCount);
        }

        [TestMethod]
        public void CustomerFactoryMethodTest() // Her testet om createcustomer metoden i factory virker.
        {
            int repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(0, repoListCount);
            CustFac.CreateCustomerToDb("Asbjørn", "jens@asbjørn.dk", "24611933", "Bispevænget 1", "5000", "Odense", "88873");
            CustFac.CreateCustomerToDb("Jesper", "jens@asbjørn.dk", "2444933", "Bispevænget 3", "5000", "Odense", "88888");
            repoListCount = CustRepo.GetList().Count;
            Assert.AreEqual(2, repoListCount);

        }

    }
}
