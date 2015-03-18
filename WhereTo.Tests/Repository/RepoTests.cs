using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhereTo.Repository;
using WhereTo.Models;
using System.Collections.Generic;

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
        public void DatabaseGetPlacesbyUserId()
        {
            Place testplace = new Place("bcfac595-1a3f-44e9-b4cc-105de3c581bb", "Jersey", true, "rough", "America");
            repo.Add(testplace);
            List<Place> place = repo.GetPlacesbyUserId("bcfac595-1a3f-44e9-b4cc-105de3c581bb") as List<Place>;
            Assert.AreEqual(1, place.Count);

        }
    }
}
