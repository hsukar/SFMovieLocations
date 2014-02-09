//---------------------------------------------------------------------
// SFMovieLocations.Controllers.SFMovieLocationsController.cs
//--------------------------------------------------------------------

namespace SFMovieLocations.Controllers
{
    #region using directives
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Newtonsoft.Json; 
    using SFMovieLocations.ActionResults;
    using SFMovieLocations.Comparers;
    using SFMovieLocations.Models;
    #endregion

    /// <summary>
    /// SFMovieLocations Controller Class
    /// </summary>
    public class SFMovieLocationsController : Controller
    {
        private SFMovieLocationsContext db = new SFMovieLocationsContext();

        /// <summary>
        /// GET: /SFMovieLocations/
        /// </summary>
        /// <returns>gets all SF movie locations</returns>
        public ActionResult Index()
        {
            var sfmovielocations = db.SFMovieLocations.ToList();

            if (sfmovielocations == null)
            {
                return HttpNotFound();
            }

            return JsonNet(sfmovielocations);
        }

        /// <summary>
        /// GET: /SFMovieLocations/MovieLocations/{id}
        /// </summary>
        /// <param name="id">SF movie location unique id</param>
        /// <returns>SF movie location matched by id</returns>
        public ActionResult MovieLocations(int id = 0)
        {
            var sfmovielocations = db.SFMovieLocations.Find(id);

            if (sfmovielocations == null)
            {
                return HttpNotFound();
            }

            return JsonNet(sfmovielocations);
        }

        /// <summary>
        /// GET: /SFMovieLocations/MovieTitles?title={title}
        /// </summary>
        /// <param name="title">SF movie title</param>
        /// <returns>SF movie locations matched by title</returns>
        public ActionResult MovieTitles(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sfmovielocations = db.SFMovieLocations.Where(movie => movie.Title.Equals(title));
            
            if (sfmovielocations == null)
            {
                return HttpNotFound();
            }

            return JsonNet(sfmovielocations);
        }

        /// <summary>
        /// GET: /SFMovieLocations/Search?prefix={prefix}&count={count}
        /// </summary>
        /// <param name="prefix">SF movie title prefix (for autocomplete)</param>
        /// <param name="count">Maximum number of results to return.  Default is 10.</param>
        /// <returns>distinct SF movie locations matched by title prefix, sorted in alphabetical descending order.</returns>
        public ActionResult Search(string prefix, int count = 10)
        {
            if (string.IsNullOrWhiteSpace(prefix) || count <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sfmovielocations =
                db.SFMovieLocations.Where(movie => movie.Title.StartsWith(prefix))
                    .OrderBy(movie => movie.Title)
                    .AsEnumerable()
                    .Distinct(new SFMovieComparer())
                    .Take(count);

            if (sfmovielocations == null)
            {
                return HttpNotFound();
            }

            return JsonNet(sfmovielocations);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private ActionResult JsonNet(SFMovieLocation sfMovieLocation)
        {
            return JsonNet(new List<SFMovieLocation>() { sfMovieLocation });
        }

        private ActionResult JsonNet(IEnumerable<SFMovieLocation> sfMovieLocations)
        {
            JsonNetResult jsonNetResult = new JsonNetResult();
            jsonNetResult.Formatting = Formatting.Indented;
            jsonNetResult.Data = sfMovieLocations;

            return jsonNetResult;
        }
    }
}