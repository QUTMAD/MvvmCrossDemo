using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using WeatherMobileApp.DataObjects;
using WeatherMobileApp.Models;

namespace WeatherMobileApp.Controllers
{
    public class LocationController : TableController<LocationAutoCompleteResult>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<LocationAutoCompleteResult>(context, Request);
        }

        // GET tables/Location
        public IQueryable<LocationAutoCompleteResult> GetAllLocationAutoCompleteResult()
        {
            return Query(); 
        }

        // GET tables/Location/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<LocationAutoCompleteResult> GetLocationAutoCompleteResult(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Location/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<LocationAutoCompleteResult> PatchLocationAutoCompleteResult(string id, Delta<LocationAutoCompleteResult> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Location
        public async Task<IHttpActionResult> PostLocationAutoCompleteResult(LocationAutoCompleteResult item)
        {
            LocationAutoCompleteResult current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Location/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteLocationAutoCompleteResult(string id)
        {
             return DeleteAsync(id);
        }
    }
}
