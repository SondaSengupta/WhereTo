using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhereTo.Models;
using WhereTo.Repository;


namespace WhereTo.Controllers
{
    public class PlaceController : ApiController
    {
        private static PlaceRepository _db = new PlaceRepository();

        // GET: /api/place
        [Route("api/place")]
        public IEnumerable<Place> Get()
        {
            return _db.GetAllPlaces();
        }

        //POST: /api/place
        [Route("api/place/")]
        public HttpResponseMessage Post([FromBody] string name)
        {
            string person = name;
           
               // _db.Add(new Place(ApplicationUserID, PlaceID, IsCompleted, PlaceComment, Category));
               return new HttpResponseMessage(HttpStatusCode.OK);
          
        }

        private object GetErrorMessages()
        {
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
    }
}
