//---------------------------------------------------------------------
// SFMovieLocations.Controllers.HomeController.cs
//--------------------------------------------------------------------


namespace SFMovieLocations.Controllers
{
    #region using directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Home Controller Class
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
