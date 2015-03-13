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
        private PlaceContext _dbContext;

        public PlaceRepository()
        {
            _dbContext = new PlaceContext();
            _dbContext.Places.Load();  
        }

    }
}