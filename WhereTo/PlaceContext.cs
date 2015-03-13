using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhereTo.Models;

namespace WhereTo
{
    public class PlaceContext : DbContext
    {
       public DbSet<Place> Places { get; set; }
        
    }
}