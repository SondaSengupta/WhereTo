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
            IEnumerable<Place> Location = _db.GetAllPlaces();
            return Location;
        }

        //POST: /api/place
        public HttpResponseMessage Post(HttpRequestMessage request, Place place)
        {
            if (ModelState.IsValid)
            {
                _db.Add(place);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private object GetErrorMessages()
        {
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
    }
}
