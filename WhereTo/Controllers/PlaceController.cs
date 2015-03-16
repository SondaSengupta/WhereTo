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
    [Authorize]
    public class PlaceController : ApiController
    {
        private static PlaceRepository _db = new PlaceRepository();

        // GET: api/PlaceController
        public IQueryable<Place> Get()
        {
            return _db.GetAllPlaces();
        }

        //POST: api/PlaceController
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
