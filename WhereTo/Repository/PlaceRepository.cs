using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhereTo;
using System.Data.Entity;
using WhereTo.Models;

namespace WhereTo.Repository
{
    public class PlaceRepository
    {
        private PlaceContext _dbContext;  //declares db field

        public PlaceRepository(string connection="PlaceContext")
        {
            _dbContext = new PlaceContext(connection); //generates new instance of PlaceContext
            _dbContext.Places.Load();  //Loads the DbSet Places, which connects the database to dbLogic
        }
        public PlaceContext Context()
        {
            return _dbContext;
        }

        public IQueryable<Models.Place> GetAllPlaces()
        {
            return _dbContext.Places;
        }

        public int GetCount()
        {
            return _dbContext.Places.Count<Place>();
        }

        public void Add(Place F)
        {
            _dbContext.Places.Add(F);
            _dbContext.SaveChanges();
        }

        public void Delete(Place F)
        {
            _dbContext.Places.Remove(F);
            _dbContext.SaveChanges();
               
        }

        public void Clear()
        {
            var allItemsQuery = from Event in _dbContext.Places select Event;
            var a = allItemsQuery.ToList<Place>();
            _dbContext.Places.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}