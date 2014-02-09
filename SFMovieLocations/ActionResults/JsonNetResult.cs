//---------------------------------------------------------------------
// SFMovieLocations.ActionResults.JsonNetResult.cs
//--------------------------------------------------------------------

namespace SFMovieLocations.ActionResults
{
    #region using directives
    using System;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using SFMovieLocations.Models;
    #endregion

    /// <summary>
    /// JsonNetResult Class extends ActionResult
    /// Overrides the Json serializer for pretty printing the Json output.
    /// 
    /// ** Code from James Newton-King to save time for the code challenge **
    /// http://james.newtonking.com/archive/2008/10/16/asp-net-mvc-and-json-net
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }

        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings();
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType)
              ? ContentType
              : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting };

                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);

                writer.Flush();
            }
        }
    }
}