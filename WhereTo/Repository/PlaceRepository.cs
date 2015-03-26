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

        public PlaceRepository()
        {
            _dbContext = new PlaceContext(); //generates new instance of PlaceContext
            _dbContext.Places.Load();  //Loads the DbSet Places, which connects the database to dbLogic
        }
        public PlaceContext Context()
        {
            return _dbContext;
        }

        public IEnumerable<Models.Place> GetAllPlaces(string userId)
        {
            var PlacesNotUser = from p in _dbContext.Places
                             where p.ApplicationUserID != userId
                             select p;
            return PlacesNotUser.ToList();
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
            var allItemsQuery = from p in _dbContext.Places select p;
            var a = allItemsQuery.ToList<Place>();
            _dbContext.Places.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }



        public IEnumerable<Place> GetPlacesbyUserId(string userId)
        {
            var PlacesbyId = from p in _dbContext.Places
                             where p.ApplicationUserID == userId
                             select p;
            return PlacesbyId.ToList();
        }

        internal IEnumerable<Place> GetPlacesbyPlaceId(int id)
        {
            var PlacesbyId = QuerybyPlaceID(id);
            return PlacesbyId.ToList();
        }


        internal void UpdatePlace(Place place)
        {
            var getPlace = from p in _dbContext.Places
                             where p.ID == place.ID
                             select p;

            List<Place> placeQuery = getPlace.ToList<Place>();
            Place item = placeQuery.First();

            item.IsCompleted = place.IsCompleted;
            item.PlaceAddress = place.PlaceAddress;
            item.PlaceComment = place.PlaceComment;
            item.PlaceName = place.PlaceName;
            item.PlacePic = place.PlacePic;
     
            _dbContext.SaveChanges();
        }

        private IQueryable<Place> QuerybyPlaceID(int id)
        {
            var PlacesbyId = from p in _dbContext.Places
                             where p.ID == id
                             select p;
            return PlacesbyId;
        }
    }
}