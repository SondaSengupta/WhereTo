using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhereTo.Models;
using WhereTo.Repository;
using Microsoft.AspNet.Identity;


namespace WhereTo.Controllers
{
    public class PlaceController : ApiController
    {
        private static PlaceRepository _db = new PlaceRepository();

        // GET: /api/place
        [Route("api/place")]
        public IEnumerable<Place> Get()
        {
            string userId = User.Identity.GetUserId();
            if (userId != null)
            {
                return _db.GetPlacesbyUserId(userId);
            }
            return _db.GetAllPlaces();
        }

        [Route("api/place/{id}")]
        public IEnumerable<Place> Get(int id)
        {

            return _db.GetPlacesbyPlaceId(id);
        }



        //POST: /api/place
        [Route("api/place/")]
        public HttpResponseMessage Post(Place place)
        {
            place.ApplicationUserID = User.Identity.GetUserId();
            _db.Add(place);
           return new HttpResponseMessage(HttpStatusCode.OK);
          
        }

        [Route("api/{id}/update")]
        [HttpPost]
        public HttpResponseMessage Update(int id)
        {
            _db.UpdateCompleted(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
