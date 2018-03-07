
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bazzr.Models;
using Bazzr;

namespace Bazzr.Tests
{
    [TestClass]
    public class Buy_OfferTests : IDisposable
    {
        public Buy_OfferTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }
        public void Dispose()
        {
            Buy_Offer.DeleteAll();
        }
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            int result = Buy_Offer.GetAll().Count;
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Save_SavesToDatabase_BuyOfferList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Buy_Offer testBuy_Offer = new Buy_Offer(1, dt, 2, 3, "a", 4, 0);
            testBuy_Offer.Save();
            List<Buy_Offer> result = Buy_Offer.GetAll();
            List<Buy_Offer> testList = new List<Buy_Offer>{testBuy_Offer};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsBuyOfferInDatabase_BuyOffer()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Buy_Offer testBuy_Offer = new Buy_Offer(1, dt, 2, 3, "a", 4, 0);
            testBuy_Offer.Save();
            Buy_Offer result = Buy_Offer.Find(testBuy_Offer.GetId());
            Assert.AreEqual(testBuy_Offer, result);
        }

        [TestMethod]
        public void Edit_EditChangesBuyOffer_BuyOffer()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            DateTime dt2 = new DateTime(2008, 1, 2, 3, 4, 5);
            Buy_Offer testBuy_Offer = new Buy_Offer(1, dt, 2, 3, "a", 4, 0);
            testBuy_Offer.Save();
            testBuy_Offer.Edit(5, dt2, 6, 7, 9, "b");
            Buy_Offer result = Buy_Offer.Find(testBuy_Offer.GetId());
            Assert.AreEqual(5, result.GetWGameId());
            Assert.AreEqual(dt2, result.GetDate());
            Assert.AreEqual(6, result.GetUserIdBuyer());
            Assert.AreEqual(7, result.GetSell_TransactionId());
            Assert.AreEqual(9, result.GetOGameId());
            Assert.AreEqual("b", result.GetComment());
        }

        [TestMethod]
        public void Delete_DeleteRemovesBuy_Offer_Buy_OfferList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Buy_Offer testBuy_Offer = new Buy_Offer(1, dt, 2, 3, "a", 4, 0);
            testBuy_Offer.Save();
            testBuy_Offer.Delete();
            List<Buy_Offer> testList = new List<Buy_Offer>{};
            List<Buy_Offer> result = Buy_Offer.GetAll();
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
