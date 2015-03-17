using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhereTo.Repository;
using WhereTo.Models;

namespace WhereTo.Tests.Repository
{
    [TestClass]
    public class RepoTests
    {
        private static PlaceRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new PlaceRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
            repo.Dispose();
        }

        [TestMethod]
        public void DatabaseAddItem()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Place());
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void DatabaseGetAllPlaces()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Place());
            Assert.AreEqual(1, repo.GetAllPlaces());
        }
    }
}
